using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                HitraterNativeMethods.initialize();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                HitraterNativeMethods.shutdown();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var aimX = (float)numericUpDownAimX.Value;
            var aimY = (float)numericUpDownAimY.Value;

            var burstLength = (uint)numericUpDownBustLength.Value;
            var iterations = (uint)numericUpDownIterations.Value;
            var maxSpread = (float)numericUpDownMaxSpread.Value;
            var recoilX = (float)numericUpDownRecoilX.Value;
            var recoilY = (float)numericUpDownRecoilY.Value;
            var spread = (float)numericUpDownSpread.Value;
            var spreadInc = (float)numericUpDownSpreadInc.Value;
            var distance = (float)numericUpDownDistance.Value;

            float[] outBody = new float[burstLength];
            float[] outHead = new float[burstLength];
            uint[] outSumBody = new uint[burstLength];
            uint[] outSumHead = new uint[burstLength];

            uint oldDist = Convert.ToUInt32(checkBox1.Checked);

            try
            {
                HitraterNativeMethods.run(oldDist, spread, maxSpread, spreadInc, distance, aimX, aimY, recoilX, recoilY, iterations, burstLength, outBody, outHead, outSumBody, outSumHead);

                treeViewBody.Nodes.Clear();
                treeViewHead.Nodes.Clear();

                float sumHead = 0.0f;
                float sumBody = 0.0f;
                for (uint i = 0; i < burstLength; ++i)
                {
                    sumBody += outBody[i];
                    sumHead += outHead[i];

                    float valBody = outBody[i] * 100.0f;
                    float valHead = outHead[i] * 100.0f;

                    treeViewBody.Nodes.Add(valBody.ToString("0.00") + " %" );
                    treeViewHead.Nodes.Add(valHead.ToString("0.00") + " %");
                }

                labelSumBody.Text = sumBody.ToString("0.00");
                labelSumHead.Text = sumHead.ToString("0.00");
            }
            catch
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
