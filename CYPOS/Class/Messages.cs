using System;
using System.Collections.Generic;
using System.Text;

namespace cypos
{
    static class Messages
    {
        #region About Messages Class

        //Writter by Rinesh PK on 17/09/2012

        #endregion

        #region Static Functions

        public static void InformationMessage(string strMsg)
        {
            MyMessageBox.ShowBox(strMsg, "CYPOS™",MyMessageBox.Buttons.OK,MyMessageBox.Icons.Information );
        }

        public static void WarningMessage(string strMsg)
        {
            MyMessageBox.ShowBox(strMsg, "CYPOS™",MyMessageBox.Buttons.OK,MyMessageBox.Icons.Warning);
        }
        public static void ErrorMessage(string strMsg)
        {
            MyMessageBox.ShowBox(strMsg, "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Error);
        }
        public static void StopMessage(string strMsg)
        {
            MyMessageBox.ShowBox(strMsg, "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Stop);
        }
        public static bool QuestionMessage(string strMsg)
        {
            bool isOk = false;
            if ((MyMessageBox.ShowBox(strMsg, "CYPOS™",MyMessageBox.Buttons.YesNo, MyMessageBox.Icons.Question))==MyMessageBox.Result.Yes)
            {
                isOk = true;
            }
            return isOk;
        }

        public static void SavedMessage()
        {
            MyMessageBox.ShowBox("Saved successfully", "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }

        public static void UpdatedMessage()
        {
            MyMessageBox.ShowBox("Updated successfully ", "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }

        public static void DeletedMessage()
        {
            MyMessageBox.ShowBox("Deleted successfully ", "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }

        public static void ExceptionMessage(string strMsg)
        {
            MyMessageBox.ShowBox(strMsg, "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Error);
        }

        public static void ExceptionMessage(string strMsg, string strCustomMessege)
        {
            MyMessageBox.ShowBox(strMsg + " " + strCustomMessege, "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Error);
        }

        public static void ReferenceExistsMessage()
        {
            MyMessageBox.ShowBox("You can't delete,reference exist", "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Warning);
        }

        public static void ReferenceExistsMessageWithString(string strReference)
        {
            MyMessageBox.ShowBox("You can't delete,reference exist in " + strReference, "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Warning);
        }

        public static void AlreadyExistMessage()
        {
            MyMessageBox.ShowBox("Already exists ", "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }

        public static void NoPrivillageMessage()
        {
            MyMessageBox.ShowBox("You are not privileged, contact administrator", "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }

        public static void FillAllDetailsMessage()
        {
            MyMessageBox.ShowBox("Please fill all mandatory details", "CYPOS™", MyMessageBox.Buttons.OK, MyMessageBox.Icons.Information);
        }
      

        public static bool DeleteMessage()
        {
            bool isOk = false;
            if ((MyMessageBox.ShowBox("Are you sure to delete ? ", "CYPOS™", MyMessageBox.Buttons.YesNo, MyMessageBox.Icons.Question))==MyMessageBox.Result.Yes)
            {
                isOk = true;
            }
            return isOk;

        }
        public static bool DeleteMessageCustom(string strMsg)
        {
            bool isOk = false;
            if ((MyMessageBox.ShowBox(strMsg, "CYPOS™", MyMessageBox.Buttons.YesNo, MyMessageBox.Icons.Question)) == MyMessageBox.Result.Yes)
            {
                isOk = true;
            }
            return isOk;
        }

        public static bool CloseMessage()
        {
            bool isOk = false;
            if ((MyMessageBox.ShowBox("Are you sure to exit ? ", "CYPOS™", MyMessageBox.Buttons.YesNo, MyMessageBox.Icons.Question)) == MyMessageBox.Result.Yes)
            {
                isOk = true;
            }
            return isOk;

        }
        public static void CloseMessage(System.Windows.Forms.Form frm)
        {
            if ((MyMessageBox.ShowBox("Are you sure to exit ? ", "CYPOS™", MyMessageBox.Buttons.YesNo, MyMessageBox.Icons.Question)) == MyMessageBox.Result.Yes)
            {
                
                frm.Close();
            }
        }
        #endregion
    }
}
