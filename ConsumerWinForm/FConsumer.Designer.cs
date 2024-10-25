namespace ConsumerWinForm
{
    partial class FConsumer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbMensagens = new ListBox();
            btnConectarConsumer = new Button();
            btnDesconectarConsumer = new Button();
            statusStrip1 = new StatusStrip();
            lbStatus = new ToolStripStatusLabel();
            lbMensagensLogs = new ListBox();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lbMensagens
            // 
            lbMensagens.FormattingEnabled = true;
            lbMensagens.ItemHeight = 15;
            lbMensagens.Location = new Point(14, 41);
            lbMensagens.Name = "lbMensagens";
            lbMensagens.Size = new Size(413, 139);
            lbMensagens.TabIndex = 0;
            // 
            // btnConectarConsumer
            // 
            btnConectarConsumer.Location = new Point(14, 12);
            btnConectarConsumer.Name = "btnConectarConsumer";
            btnConectarConsumer.Size = new Size(144, 23);
            btnConectarConsumer.TabIndex = 1;
            btnConectarConsumer.Text = "Conectar Consumer";
            btnConectarConsumer.UseVisualStyleBackColor = true;
            btnConectarConsumer.Click += btnConectarConsumer_Click;
            // 
            // btnDesconectarConsumer
            // 
            btnDesconectarConsumer.Location = new Point(279, 12);
            btnDesconectarConsumer.Name = "btnDesconectarConsumer";
            btnDesconectarConsumer.Size = new Size(146, 23);
            btnDesconectarConsumer.TabIndex = 2;
            btnDesconectarConsumer.Text = "Desconectar Consumer";
            btnDesconectarConsumer.UseVisualStyleBackColor = true;
            btnDesconectarConsumer.Click += button1_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lbStatus });
            statusStrip1.Location = new Point(0, 336);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(439, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbStatus
            // 
            lbStatus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(49, 17);
            lbStatus.Text = "lbStatus";
            // 
            // lbMensagensLogs
            // 
            lbMensagensLogs.FormattingEnabled = true;
            lbMensagensLogs.ItemHeight = 15;
            lbMensagensLogs.Location = new Point(12, 209);
            lbMensagensLogs.Name = "lbMensagensLogs";
            lbMensagensLogs.Size = new Size(413, 124);
            lbMensagensLogs.TabIndex = 4;
            // 
            // FConsumer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 358);
            Controls.Add(lbMensagensLogs);
            Controls.Add(statusStrip1);
            Controls.Add(btnDesconectarConsumer);
            Controls.Add(btnConectarConsumer);
            Controls.Add(lbMensagens);
            Name = "FConsumer";
            Text = "Consumer";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbMensagens;
        private Button btnConectarConsumer;
        private Button btnDesconectarConsumer;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbStatus;
        private ListBox lbMensagensLogs;
    }
}
