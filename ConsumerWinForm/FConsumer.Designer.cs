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
            button1 = new Button();
            SuspendLayout();
            // 
            // lbMensagens
            // 
            lbMensagens.FormattingEnabled = true;
            lbMensagens.ItemHeight = 15;
            lbMensagens.Location = new Point(14, 41);
            lbMensagens.Name = "lbMensagens";
            lbMensagens.Size = new Size(413, 304);
            lbMensagens.TabIndex = 0;
            // 
            // btnConectarConsumer
            // 
            btnConectarConsumer.Location = new Point(281, 12);
            btnConectarConsumer.Name = "btnConectarConsumer";
            btnConectarConsumer.Size = new Size(144, 23);
            btnConectarConsumer.TabIndex = 1;
            btnConectarConsumer.Text = "Conectar Consumer";
            btnConectarConsumer.UseVisualStyleBackColor = true;
            btnConectarConsumer.Click += btnConectarConsumer_Click;
            // 
            // button1
            // 
            button1.Location = new Point(14, 12);
            button1.Name = "button1";
            button1.Size = new Size(146, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FConsumer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(439, 358);
            Controls.Add(button1);
            Controls.Add(btnConectarConsumer);
            Controls.Add(lbMensagens);
            Name = "FConsumer";
            Text = "Consumer";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lbMensagens;
        private Button btnConectarConsumer;
        private Button button1;
    }
}
