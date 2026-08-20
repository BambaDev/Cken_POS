# ============================================================================
# CYPOS Phase 1 - Script de déploiement automatique
# ============================================================================
# Date: 2026-05-24
# Version: 1.0
#
# Ce script automatise le déploiement de CYPOS Phase 1 en production
#
# IMPORTANT: Exécuter ce script en tant qu'administrateur
# ============================================================================

param(
    [string]$SourcePath = "C:\Users\Bamba\Documents\Visual Studio 2022\Projets\Claude\CYPOS\Sourcecode\CYPOS\bin\Release",
    [string]$DestinationPath = "C:\CYPOS\Production",
    [string]$BackupPath = "C:\CYPOS\Backups",
    [switch]$TestMode = $false
)

# Couleurs pour l'affichage
function Write-Success { param([string]$Message) Write-Host "✓ $Message" -ForegroundColor Green }
function Write-Info { param([string]$Message) Write-Host "→ $Message" -ForegroundColor Cyan }
function Write-Warning { param([string]$Message) Write-Host "⚠ $Message" -ForegroundColor Yellow }
function Write-Error { param([string]$Message) Write-Host "✗ $Message" -ForegroundColor Red }
function Write-Step { param([string]$Message) Write-Host "`n========================================" -ForegroundColor Magenta; Write-Host $Message -ForegroundColor Magenta; Write-Host "========================================`n" -ForegroundColor Magenta }

# ============================================================================
# ÉTAPE 0 : Vérifications préalables
# ============================================================================

Write-Step "ÉTAPE 0 : Vérifications préalables"

# Vérifier les droits admin
$isAdmin = ([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
if (-not $isAdmin) {
    Write-Error "Ce script doit être exécuté en tant qu'administrateur"
    Write-Info "Clic droit → Exécuter en tant qu'administrateur"
    exit 1
}
Write-Success "Droits administrateur : OK"

# Vérifier que le dossier source existe
if (-not (Test-Path $SourcePath)) {
    Write-Error "Dossier source introuvable : $SourcePath"
    Write-Info "Compilez d'abord le projet en Release"
    exit 1
}
Write-Success "Dossier source trouvé : $SourcePath"

# Vérifier que l'exécutable existe
$exePath = Join-Path $SourcePath "CYPOS Restaurant.exe"
if (-not (Test-Path $exePath)) {
    Write-Error "Exécutable introuvable : $exePath"
    exit 1
}
Write-Success "Exécutable trouvé"

# Mode test
if ($TestMode) {
    Write-Warning "MODE TEST ACTIVÉ - Aucune modification ne sera faite"
    $DestinationPath = "$DestinationPath-TEST"
}

# ============================================================================
# ÉTAPE 1 : Création des dossiers
# ============================================================================

Write-Step "ÉTAPE 1 : Création des dossiers"

$folders = @($DestinationPath, $BackupPath, "$DestinationPath\Errors", "$DestinationPath\Images", "$DestinationPath\ItemImages")

foreach ($folder in $folders) {
    if (-not (Test-Path $folder)) {
        New-Item -ItemType Directory -Path $folder -Force | Out-Null
        Write-Success "Dossier créé : $folder"
    } else {
        Write-Info "Dossier existe déjà : $folder"
    }
}

# ============================================================================
# ÉTAPE 2 : Backup de l'installation existante
# ============================================================================

Write-Step "ÉTAPE 2 : Backup de l'installation existante"

if (Test-Path "$DestinationPath\CYPOS Restaurant.exe") {
    $timestamp = Get-Date -Format "yyyyMMdd_HHmmss"
    $backupFolder = Join-Path $BackupPath "Backup_$timestamp"

    Write-Info "Création du backup dans : $backupFolder"

    if (-not $TestMode) {
        Copy-Item -Path $DestinationPath -Destination $backupFolder -Recurse -Force
        Write-Success "Backup créé avec succès"
        Write-Info "Vous pouvez restaurer avec : Copy-Item '$backupFolder\*' '$DestinationPath' -Recurse -Force"
    } else {
        Write-Warning "[TEST] Backup simulé"
    }
} else {
    Write-Info "Première installation - Pas de backup nécessaire"
}

# ============================================================================
# ÉTAPE 3 : Arrêt de l'application
# ============================================================================

Write-Step "ÉTAPE 3 : Arrêt de l'application"

$processName = "CYPOS Restaurant"
$processes = Get-Process -Name $processName -ErrorAction SilentlyContinue

if ($processes) {
    Write-Warning "Application CYPOS en cours d'exécution détectée"
    Write-Info "Fermeture des $($processes.Count) instance(s)..."

    if (-not $TestMode) {
        $processes | ForEach-Object {
            $_.CloseMainWindow() | Out-Null
            Start-Sleep -Seconds 2
            if (-not $_.HasExited) {
                $_ | Stop-Process -Force
            }
        }
        Write-Success "Application fermée"
    } else {
        Write-Warning "[TEST] Fermeture simulée"
    }
} else {
    Write-Success "Aucune instance en cours d'exécution"
}

# ============================================================================
# ÉTAPE 4 : Copie des fichiers
# ============================================================================

Write-Step "ÉTAPE 4 : Copie des fichiers"

Write-Info "Source : $SourcePath"
Write-Info "Destination : $DestinationPath"

if (-not $TestMode) {
    # Liste des fichiers à copier
    $filesToCopy = @(
        "CYPOS Restaurant.exe",
        "CYPOS Restaurant.exe.config",
        "*.dll",
        "*.pdb" # Fichiers de debug pour meilleurs messages d'erreur
    )

    $totalFiles = 0
    foreach ($pattern in $filesToCopy) {
        $files = Get-ChildItem -Path $SourcePath -Filter $pattern -File
        foreach ($file in $files) {
            Copy-Item -Path $file.FullName -Destination $DestinationPath -Force
            $totalFiles++
        }
    }

    Write-Success "Copié $totalFiles fichier(s)"
} else {
    Write-Warning "[TEST] Copie simulée"
}

# ============================================================================
# ÉTAPE 5 : Vérification des dossiers requis
# ============================================================================

Write-Step "ÉTAPE 5 : Vérification des dossiers requis"

$requiredFolders = @("Errors", "Images", "ItemImages")
foreach ($folder in $requiredFolders) {
    $folderPath = Join-Path $DestinationPath $folder
    if (Test-Path $folderPath) {
        Write-Success "Dossier OK : $folder"
    } else {
        Write-Error "Dossier manquant : $folder"
        if (-not $TestMode) {
            New-Item -ItemType Directory -Path $folderPath -Force | Out-Null
            Write-Success "Dossier créé : $folder"
        }
    }
}

# ============================================================================
# ÉTAPE 6 : Vérification de l'installation
# ============================================================================

Write-Step "ÉTAPE 6 : Vérification de l'installation"

$exeInstalled = Join-Path $DestinationPath "CYPOS Restaurant.exe"
if (Test-Path $exeInstalled) {
    $fileInfo = Get-Item $exeInstalled
    Write-Success "Installation réussie"
    Write-Info "Fichier : $exeInstalled"
    Write-Info "Taille : $([math]::Round($fileInfo.Length / 1MB, 2)) MB"
    Write-Info "Date : $($fileInfo.LastWriteTime)"
} else {
    Write-Error "Échec de l'installation - Exécutable introuvable"
    exit 1
}

# ============================================================================
# ÉTAPE 7 : Création des raccourcis
# ============================================================================

Write-Step "ÉTAPE 7 : Création des raccourcis"

if (-not $TestMode) {
    $WshShell = New-Object -ComObject WScript.Shell

    # Raccourci Bureau
    $desktopPath = [Environment]::GetFolderPath("Desktop")
    $shortcutPath = Join-Path $desktopPath "CYPOS Restaurant.lnk"
    $shortcut = $WshShell.CreateShortcut($shortcutPath)
    $shortcut.TargetPath = $exeInstalled
    $shortcut.WorkingDirectory = $DestinationPath
    $shortcut.Description = "CYPOS Restaurant - Phase 1"
    $shortcut.Save()
    Write-Success "Raccourci bureau créé"

    # Raccourci Menu Démarrer
    $startMenuPath = [Environment]::GetFolderPath("CommonStartMenu")
    $startMenuShortcut = Join-Path $startMenuPath "Programs\CYPOS Restaurant.lnk"
    $shortcut = $WshShell.CreateShortcut($startMenuShortcut)
    $shortcut.TargetPath = $exeInstalled
    $shortcut.WorkingDirectory = $DestinationPath
    $shortcut.Description = "CYPOS Restaurant - Phase 1"
    $shortcut.Save()
    Write-Success "Raccourci menu démarrer créé"
} else {
    Write-Warning "[TEST] Création raccourcis simulée"
}

# ============================================================================
# ÉTAPE 8 : Rapport final
# ============================================================================

Write-Step "RAPPORT FINAL"

Write-Host ""
Write-Host "╔════════════════════════════════════════════════════════════╗" -ForegroundColor Green
Write-Host "║                                                            ║" -ForegroundColor Green
Write-Host "║          ✓ DÉPLOIEMENT PHASE 1 TERMINÉ AVEC SUCCÈS        ║" -ForegroundColor Green
Write-Host "║                                                            ║" -ForegroundColor Green
Write-Host "╚════════════════════════════════════════════════════════════╝" -ForegroundColor Green
Write-Host ""

Write-Info "Installation : $DestinationPath"
Write-Info "Backup : $BackupPath"
Write-Info "Logs : $DestinationPath\Errors"

Write-Host ""
Write-Host "PROCHAINES ÉTAPES :" -ForegroundColor Yellow
Write-Host "1. Tester le login avec admin/admin"
Write-Host "2. Créer un nouvel utilisateur"
Write-Host "3. Tester un client avec apostrophe (ex: O'Brien)"
Write-Host "4. Vérifier les logs dans Errors\"
Write-Host "5. Monitoring pendant 24-48h"
Write-Host ""

Write-Info "Pour lancer l'application : $exeInstalled"

if ($TestMode) {
    Write-Warning "MODE TEST - Aucune modification réelle n'a été faite"
    Write-Info "Relancez sans -TestMode pour déployer réellement"
}

# ============================================================================
# FIN DU SCRIPT
# ============================================================================
