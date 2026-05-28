using System;
using System.Windows.Forms;

namespace cypos
{
	/// <summary>
	/// Implements a ToolStripDropDown container for a ColorPalette control.
	/// </summary>
	internal class ColorDropDown : ToolStripDropDown
	{
		protected ColorPalette _palette;
		protected ToolStripItem _moreColorsButton;

		public bool MoreColorsButton { get; set; }

		// Construction
		public ColorDropDown()
		{
			_palette = new ColorPalette();
			ToolStripControlHost container = new ToolStripControlHost(_palette);
			Items.Add(container);
			_moreColorsButton = Items.Add("More Colors...");
			_moreColorsButton.Margin = new Padding(_palette.Margins);
			_moreColorsButton.ToolTipText = "Select from additional colors";
			_moreColorsButton.Click += new EventHandler(_moreColorsButton_Click);
			MoreColorsButton = true;
		}

		// 'More Colors' button clicked
		void _moreColorsButton_Click(object sender, EventArgs e)
		{
			_palette.ShowColorDialog();
		}

		/// <summary>
		/// Returns the underlying ColorPalette control used by this control.
		/// </summary>
		public ColorPalette GetColorPaletteControl()
		{
			return _palette;
		}

		// Drop-down palette is opening
		protected override void OnOpening(System.ComponentModel.CancelEventArgs e)
		{
			base.OnOpening(e);

			// Show/hide 'More Colors' button
			_moreColorsButton.Visible = MoreColorsButton;

			// Set background color
			ToolStripProfessionalRenderer renderer = Renderer as ToolStripProfessionalRenderer;
			if (renderer != null)
				_palette.BackColor = renderer.ColorTable.ToolStripDropDownBackground;
		}

		// Drop-down palette has opened
		protected override void OnOpened(EventArgs e)
		{
			base.OnOpened(e);
			_palette.Focus();
		}
	}
}
