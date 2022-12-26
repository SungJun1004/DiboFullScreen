using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using FullScreen;

namespace DiboFullScreen
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser _chrome = null;
        Rectangle fullScrenn_bounds;
        public Form1()
        {
            InitializeComponent();
            InitializeCefSharp("http://sap.com");
        }

        private void InitializeCefSharp(string StrURL)
        {
           
            //쿠키 데이터 사용하는 방법
            CefSettings settings = new CefSettings();
            settings.CachePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CEF";
            Cef.Initialize(settings);
           
            //웹 사이트 이동
             _chrome = new ChromiumWebBrowser(StrURL);

            //한국어 설정
            _chrome.BrowserSettings.AcceptLanguageList = "ko-KR";
            //Main Form에 CefSharp컨트롤 추가
            this.Controls.Add(_chrome);
            //Main Form 전체 영역에 붙이기
            _chrome.Dock = DockStyle.Fill;



        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            //this.Size = new Size(2000,1400);
            //this.Location = new Point(0,0);
            FormFullScreen();
            InitializeURL();


        }

        private void FormFullScreen()
        {
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;

            fullScrenn_bounds = Rectangle.Empty;

            foreach (var screen in Screen.AllScreens)
            {
                fullScrenn_bounds = Rectangle.Union(fullScrenn_bounds, screen.Bounds);
            }
            this.Size = new Size(fullScrenn_bounds.Width, fullScrenn_bounds.Height);
            this.Location = new Point(fullScrenn_bounds.Left, fullScrenn_bounds.Top);
          //  MessageBox.Show(fullScrenn_bounds.Width.ToString()) ;
        }
        private void InitializeURL()
        {
            Form2 OpenCustURL = new Form2();
            OpenCustURL.ShowDialog();

            // 입력URL 호출
            _chrome.LoadUrl(Form2.URLMessage);


        }

    }
}
