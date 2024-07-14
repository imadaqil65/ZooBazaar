using Infrastructure.Databases.Orders;
using Logic.Services.Cart;
using BarcodeStandard;
using SkiaSharp;
using USB_Barcode_Scanner;

namespace ZooProjectTicketChecker
{
	public partial class Form1 : Form
	{
		private OrderManager orderManager;
		private List<Image> barcodeImages;

		public Form1()
		{
			InitializeComponent();
			orderManager = new OrderManager(new DbOrder());
			orderManager = new OrderManager(new DbOrder());
			this.Activated += Form1_Activated;
			BarcodeScanner barcodeScanner = new BarcodeScanner(BarcodeTxtBx);
			barcodeScanner.BarcodeScanned += BarcodeScanner_BarcodeScanned;
		}

		private void Form1_Activated(object? sender, EventArgs e)
		{
			BarcodeTxtBx.Focus();
		}

		private void BarcodeScanner_BarcodeScanned(object? sender, BarcodeScannerEventArgs e)
		{
			BarcodeTxtBx.Clear();
			if (long.TryParse(e.Barcode, out long barcodeValue))
			{
				if (orderManager.MakeTicketUsed(Convert.ToInt64(e.Barcode)))
				{
					MessageBox.Show("Ticket has been updated");

					return;
				}
				MessageBox.Show("Ticket has been already used");
				return;
			}
			MessageBox.Show("Unknown barcode");
		}

		/*		private void GenerateBarcodeBtn_Click(object sender, EventArgs e)
				{
					Barcode barcode = new Barcode();
					SKColor foreColor = SKColors.Black;
					SKColor backColor = SKColors.Transparent;
					SKImage img = barcode.Encode(BarcodeStandard.Type.Code128, BarcodeTxtBx.Text);

					using (MemoryStream ms = new MemoryStream())
					{
						img.Encode(SKEncodedImageFormat.Png, 100).SaveTo(ms);
						Image image = Image.FromStream(ms);
						BarcodeBox.Image = image;
					}
				}*/
	}
}
