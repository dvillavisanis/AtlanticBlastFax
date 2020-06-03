using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtlanticBlastFax
{
    public partial class Form1 : Form
    {
        private List<eMailAccounts> eAccounts;
        private LoadFaxNumbers faxList;
        private string msgBody;
        private MailMessage mailMessage;
        private SmtpClient smtpClient;
        private eMailAccounts eCurrentAccount;

        public Form1()
        {

            eAccounts = new List<eMailAccounts>();

            eAccounts.Add(new eMailAccounts("001", "Abcfax@atlanticbiologicals.com", "Peppermint133!", "First ABC Email"));
            eAccounts.Add(new eMailAccounts("NAS", "Fax@nasrx.com", "Peppermint144!", "13053518790"));
            eAccounts.Add(new eMailAccounts("001", "Abcfax2@atlanticbiologicals.com", "Peppermint133!", "13056752711"));



            InitializeComponent();
            btn_loadDoc.Enabled = false;
            Btn_LoadNumber.Enabled = false;

            Btn_SendFax.Enabled = false;
            LoadAccounts(cbCompany.Text);
            cbAccount.Text = null;


        }

        /// <summary>
        /// Click event of sendfax
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_SendFax_Click(object sender, EventArgs e)
        {
            //  if (faxList.faxNumbers.Count > 0)
            //  {
            //      MessageBox.Show($"Sending {faxList.faxNumbers.Count.ToString()} Faxes");
            Boolean bStop = false;
            initSMTP(cbCompany.Text);
            pbSendingStatus.Maximum = faxList?.faxNumbers.Count ?? 0;
            pbSendingStatus.Step = 1;
            pbSendingStatus.Show();
            Cursor.Current = Cursors.WaitCursor;
            if (cbTestOnly.Checked)
            {

                sendEmail(tbTestEmail.Text);
                MessageBox.Show("Test email was sent");
            }
            else
            {
                int waitcount = 0;
                int current = 0;
                foreach (PhoneNumbers fax in faxList.faxNumbers)
                {
                    current++;
                    waitcount++;
                    pbSendingStatus.PerformStep();
                    if (!bStop)
                    {
                        try
                        {
                            sendEmail($"1{fax.PhoneNumber}@metrofax.com");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        // bStop = true;
                    }
                    tbCurrent.Text = current.ToString();
                    tbCurrent.Refresh();
                    if (waitcount > 10)
                    {
                        // slow down the 
                        System.Threading.Thread.Sleep(1500);
                        waitcount = 0;
                    }
                }

                MessageBox.Show($"{faxList?.faxNumbers.Count ?? 0}  Faxes have been sent.");
            }
            Cursor.Current = Cursors.Arrow;
        }

        private void Btn_LoadNumber_Click(object sender, EventArgs e)
        {
            string Comp = cbCompany.Text;
            Cursor.Current = Cursors.WaitCursor;
            faxList = new LoadFaxNumbers(Comp);
            tbFaxCount.Text = faxList.faxNumbers.Count.ToString();
            btn_loadDoc.Enabled = true;
            Cursor.Current = Cursors.Arrow;
        }

        private void btn_loadDoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select A File";
            openDialog.Filter = "Doc Files (*.DOCx)|*.DOCx" + "|" +
                                "All Files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string file = openDialog.FileName;
                GetFile(file);
                tbFilename.Text = file;
                CreateEmail(file, cbCompany.Text);
                Btn_SendFax.Enabled = true;
            }
        }

        public void GetFile(string file)
        {
            msgBody = System.IO.File.ReadAllText(file);
        }
        /// <summary>
        /// Initialize smtp connection
        /// </summary>
        /// <param name="company"></param>
        public void initSMTP(string company)
        {
           // eMailAccounts eAcctn;
            smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Host = "smtp.office365.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 200000;// default is 100,000

            if (cbAccount.Text == "" || cbAccount.Text == null)
            {
                MessageBox.Show(this, "Must Select an Account", "More Info Needed");
                return;
            }
            else
            {
               // eAcctn = eAccounts.Find(x => x.emailName == cbAccount.Text);
                if (eCurrentAccount != null)
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential(eCurrentAccount.email, eCurrentAccount.emailpw);
                }
                else
                {
                    MessageBox.Show(this, $"Unable to find Account{cbAccount.Text}", "Error");
                }
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="company"></param>
        public void CreateEmail(string file, string company)
        {
            mailMessage = new MailMessage();

            string Body = tbSubjectLine.Text;
          
            if (eCurrentAccount != null)
            { 
                mailMessage.From = new MailAddress(eCurrentAccount.email);
                mailMessage.Subject = tbSubjectLine.Text;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = Body;
                Attachment afile = new Attachment(file);
                mailMessage.Attachments.Add(afile);
            }
            else
            {
                return;
            }
               //mailMessage.To.Add(ConfigurationSettings.AppSettings["RequesEmail"].ToString());
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Fax"></param>
        public void sendEmail(string Fax)
        {
            try
            {
                mailMessage.To.Clear();
                mailMessage.To.Add(Fax);
                smtpClient.Send(mailMessage);
            }
            catch (SmtpException smtpException)
            {
                if (smtpException.StatusCode == SmtpStatusCode.MailboxBusy)
                    throw smtpException;

                // To check if the client is authenticated or is allowed to send email using the specified SMTP host 
                if (smtpException.StatusCode == SmtpStatusCode.ClientNotPermitted)
                    throw smtpException;
                // The following code checks if the email message is too large to be stored in destination mailbox 

                if (smtpException.StatusCode == SmtpStatusCode.ExceededStorageAllocation)
                    throw smtpException;
                // To check if the email was successfully sent to the SMTP service 

                if (smtpException.StatusCode == SmtpStatusCode.Ok)
                    throw smtpException;
                // When the SMTP host is not found check for the following value 

                if (smtpException.StatusCode == SmtpStatusCode.GeneralFailure)
                    throw smtpException;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbSendingStatus.Hide();
        }

        private void cbTestOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbTestOnly.Checked)
            {
                tbTestEmail.Visible = false;
                lbTestEmail.Visible = false;
            }
            else
            {
                tbTestEmail.Visible = true;
                lbTestEmail.Visible = true;
            }
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbAccount.Items.Clear();
            cbAccount.Text = "";
            LoadAccounts(cbCompany.Text.ToUpper());
        }



        private void LoadAccounts(string company)
        {
            foreach (eMailAccounts acct in eAccounts)

            {
                if (acct.company.ToUpper() == company)
                {
                    cbAccount.Items.Add(acct.emailName);
                }
            }
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            eCurrentAccount = eAccounts.Find(x => x.emailName == cbAccount.Text);
            if (eCurrentAccount != null)
            {
                btn_loadDoc.Enabled = true;
                Btn_LoadNumber.Enabled = true;

                // smtpClient.Credentials = new System.Net.NetworkCredential(eCurrentAccount.email, eCurrentAccount.emailpw);
            }
            else

            {
                btn_loadDoc.Enabled = false;
                Btn_LoadNumber.Enabled = false;

                MessageBox.Show(this, $"Unable to find Account{cbAccount.Text}", "Error");
            }

        }
    }

    class eMailAccounts
    {
        public string company { get; set; }
        public string email { get; set; }
        public string emailpw { get; set; }

        public string emailName { get; set; }


        public eMailAccounts(string acompany, string aEmail, string aEmailpw, string aName)
        {
            this.company = acompany;
            this.email = aEmail;
            this.emailpw = aEmailpw;
            this.emailName = aName;
        }

    }
}









