/*
 * Created by SharpDevelop.
 * User: 1
 * Date: 26.06.2020
 * Time: 23:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace StandOtkat
{
	class Program
	{
		public static void Main(string[] args)
		{
						
			// TODO: Implement Functionality Here
			
			Application.Run(new MyForm());
			
			
		}
		
		
		
	}
	
	
	class MyForm : Form
	{
		
		Label label1;
		
		TextBox textbox1;
		
		public MyForm()
		{
			Height = 1024; //800 //640
			Width = 768; //600 //480
		}
		
		
		protected override void OnPaint(PaintEventArgs e)
		{
			/*-------------------------ОТКАТ СТЕНДА 1.0-------------------------*/
			label1 = new Label();
			label1.Font = new Font("Times New Roman", 20);
			//label1.Size = new Size(100, 100);
			label1.Location = new Point(10, 0);
			label1.Text = "Откат стенда v. 1.0";
			label1.AutoSize = false;
			
			label1.TextAlign = ContentAlignment.MiddleCenter;
			label1.Width = 500;
			Controls.Add(label1);
			
			
			/*-------------------------Путь к стенду-------------------------*/
			label1 = new Label();
			label1.Font = new Font("Times New Roman", 20);
			//label1.Size = new Size(100, 100);
			label1.Location = new Point(0, 40);
			label1.Text = "Путь к стенду:";
			label1.AutoSize = false;
			
			//label1.TextAlign = ContentAlignment.MiddleCenter;
			label1.Height = 50;
			label1.Width = 250;
			
			Controls.Add(label1);
			
			/*-------------------------Путь к бекапу-------------------------*/
			label1 = new Label();
			label1.Font = new Font("Times New Roman", 20);
			//label1.Size = new Size(100, 100);
			label1.Location = new Point(0, 90);
			label1.Text = "Путь к бекапу:";
			label1.AutoSize = false;
			
			//label1.TextAlign = ContentAlignment.MiddleCenter;
			label1.Height = 50;
			label1.Width = 250;
			
			Controls.Add(label1);
			
			
			/*-------------------------TextBox1-------------------------*/
			textbox1 = new TextBox();
			textbox1.Location = new Point(300, 46);
			textbox1.Width = 300;
			//textbox1.MaximumSize = new Size(100, 100);
			//textbox1.MinimumSize = new Size(100, 100);
			textbox1.Text = ConfigurationManager.AppSettings["PathToStand"].ToString();
			
			Controls.Add(textbox1);
			
			
			/*-------------------------TextBox1-------------------------*/
			textbox1 = new TextBox();
			textbox1.Location = new Point(300, 96);
			textbox1.Width = 300;
			//textbox1.MaximumSize = new Size(100, 100);
			//textbox1.MinimumSize = new Size(100, 100);
			
			textbox1.Text = ConfigurationManager.AppSettings["PathToBackup"].ToString();
			
			Controls.Add(textbox1);
			
			
			/*Кнопка Считать*/
			Button savebutton = new Button();
			savebutton.Location = new Point(200, 196);
			savebutton.Text = "Считать";
			
			
			Controls.Add(savebutton);
			
			/*Копка Сохранить*/
			savebutton = new Button();
			savebutton.Location = new Point(300, 196);
			savebutton.Text = "Сохранить";
			savebutton.Click += SaveButtonClick;
			
			Controls.Add(savebutton);
			
			
			
			
			
			
			base.OnPaint(e);
		}
		
		
		protected void SaveButtonClick(object who, EventArgs e)
		{
			//ConfigurationManager.AppSettings["PathToStand"] = "СУПЕР";
			//ConfigurationManager.RefreshSection("PathToStand");
			
			System.Configuration.Configuration currentConfig = ConfigurationManager. OpenExeConfiguration( ConfigurationUserLevel.None);
			currentConfig.AppSettings.Settings["PathToStand"].Value = "111111111111";
			//currentConfig.AppSettings.Settings["database"].Value = _serverTextBox.Text;
			currentConfig.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
			
			currentConfig.AppSettings.Settings["PathToStand"].Value = "44444444444";
			
			
			MessageBox.Show("Настройки сохранены");
		}
		
		
		
	}
}