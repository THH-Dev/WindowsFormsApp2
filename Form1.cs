using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        CogAcqFifoTool AcqFifoTool;
        CogImage8Grey cogImage8Grey;
        string fileVpp = @"C:\Users\Admin\Desktop\line-scan\AcqFifo.vpp";
        Mat mat;
        object lockObj = new object();
        CogImageStitch cogImageStitch;

        public Form1()
        {
            InitializeComponent();
        }

        private void sendLog(string log)
        {
            Console.WriteLine(log);
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (mat != null && mat.Size().Width > 0)
            Cv2.ImShow("hi", mat);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Set reference to CogAcqFifoTool created by Edit Control
            //The Acq Fifo Edit Control creates its subject when its AutoCreateTool property is True
            AcqFifoTool = CogSerializer.LoadObjectFromFile(fileVpp) as CogAcqFifoTool;
            AcqFifoTool = cogAcqFifoEditV21.Subject;
            AcqFifoTool.Changed += AcqFifoTool_Changed;
            AcqFifoTool.Ran += AcqFifoTool_Ran;
            //Operator will be Nothing if no Frame Grabber is available.  Disable the Frame Grabber
            //option on the "VisionPro Demo" tab if no frame grabber available.
            if (AcqFifoTool.Operator == null)
            {
                MessageBox.Show("AcqFifoTool.Operator");
            }

        }

        private void AcqFifoTool_Changed(object sender, CogChangedEventArgs e)
        {
            sendLog("AcqFifoTool_Changed");
        }

        int static_AcqFifoTool_Ran_numacqs = 0;
        bool bIsFirstImg = false;
        private void AcqFifoTool_Ran(object sender, EventArgs e)
        {
            sendLog("AcqFifoTool_Ran");
            lock(lockObj)
            {
                cogImage8Grey = AcqFifoTool.OutputImage as CogImage8Grey;
                if (cogImage8Grey == null)
                    return;

                
                //decode 2
                Bitmap bitmap = cogImage8Grey.ToBitmap();
                Mat temp = bitmap.ToMat();
                byte[] data = temp.ToBytes();
                Mat src2 = new Mat(256, 4096, MatType.CV_8UC1);
                src2.SetArray(data);
                if (!src2.Empty())
                {
                    //Console.WriteLine("Mat SizeX: {0}", src2.Size().Width);
                    //Console.WriteLine("Mat SizeY: {0}", src2.Size().Height);
                    //Console.WriteLine("Mat Channels: {0}", src2.Channels());

                    if (!bIsFirstImg)
                    {
                        bIsFirstImg = true;
                        mat = src2.Clone();
                    }
                    else
                    {
                        Cv2.VConcat(mat, src2, mat);
                    }
                    src2.Release();
                }
            }


            // Run the garbage collector to free unused images
            static_AcqFifoTool_Ran_numacqs += 1;
            if (static_AcqFifoTool_Ran_numacqs > 4)
            {
                GC.Collect();
                static_AcqFifoTool_Ran_numacqs = 0;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AcqFifoTool.Changed += AcqFifoTool_Changed;
            AcqFifoTool.Ran += AcqFifoTool_Ran;
            AcqFifoTool.Dispose();
        }

        string img1 = @"G:\Program\_example\ImageStitchTest_V2Controls\ImageStitchTest_V2Controls\4Cam Test\Cam OL.tif";
        string img2 = @"G:\Program\_example\ImageStitchTest_V2Controls\ImageStitchTest_V2Controls\4Cam Test\Cam OR.tif";
        string img3 = @"G:\Program\_example\ImageStitchTest_V2Controls\ImageStitchTest_V2Controls\4Cam Test\Cam UL.tif";
        string img4 = @"G:\Program\_example\ImageStitchTest_V2Controls\ImageStitchTest_V2Controls\4Cam Test\Cam UR.tif";
        List<CogImage8Grey> listCogImage = new List<CogImage8Grey>();
        private void btnLoad4Img_Click(object sender, EventArgs e)
        {
            
            Bitmap bitmap1 = new Bitmap(img1);
            Bitmap bitmap2 = new Bitmap(img2);
            Bitmap bitmap3 = new Bitmap(img3);
            Bitmap bitmap4 = new Bitmap(img4);

            List<Bitmap> listImage = new List<Bitmap>(); 
            listImage.Add(bitmap1);
            listImage.Add(bitmap2);
            listImage.Add(bitmap3);
            listImage.Add(bitmap4);

            
            foreach(Bitmap bitmap in listImage)
            {
                CogImage8Grey cogImage = new CogImage8Grey(bitmap);
                listCogImage.Add(cogImage);
            }



        }

        private void btnStitchImage_Click(object sender, EventArgs e)
        {
            // Get the data for the new image
            Int32 height = 950;
            Int32 width = 1250;
            CogImageStitch imgStitch = new CogImageStitch();
            CogTransform2DLinear trans = new CogTransform2DLinear();

            // Allocate the blending buffer
            imgStitch.AllocateBlendingBuffer(width, height, trans);


        }
    }
}
