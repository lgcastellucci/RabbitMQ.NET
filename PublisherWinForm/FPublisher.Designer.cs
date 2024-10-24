namespace PublisherWinForm
{
    partial class FPublisher
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
            lbPrefixoMensagem = new Label();
            lbMensagens = new ListBox();
            btnEnviaMensagem = new Button();
            tbPrefixoMensagem = new TextBox();
            nQuantidade = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nQuantidade).BeginInit();
            SuspendLayout();
            // 
            // lbPrefixoMensagem
            // 
            lbPrefixoMensagem.AutoSize = true;
            lbPrefixoMensagem.Location = new Point(12, 12);
            lbPrefixoMensagem.Name = "lbPrefixoMensagem";
            lbPrefixoMensagem.Size = new Size(106, 15);
            lbPrefixoMensagem.TabIndex = 0;
            lbPrefixoMensagem.Text = "Prefixo Mensagem";
            // 
            // lbMensagens
            // 
            lbMensagens.FormattingEnabled = true;
            lbMensagens.ItemHeight = 15;
            lbMensagens.Location = new Point(12, 69);
            lbMensagens.Name = "lbMensagens";
            lbMensagens.Size = new Size(318, 289);
            lbMensagens.TabIndex = 1;
            // 
            // btnEnviaMensagem
            // 
            btnEnviaMensagem.Location = new Point(255, 30);
            btnEnviaMensagem.Name = "btnEnviaMensagem";
            btnEnviaMensagem.Size = new Size(75, 23);
            btnEnviaMensagem.TabIndex = 2;
            btnEnviaMensagem.Text = "Envia Mensagem";
            btnEnviaMensagem.UseVisualStyleBackColor = true;
            btnEnviaMensagem.Click += btnEnviaMensagem_Click;
            // 
            // tbPrefixoMensagem
            // 
            tbPrefixoMensagem.Location = new Point(12, 30);
            tbPrefixoMensagem.Name = "tbPrefixoMensagem";
            tbPrefixoMensagem.Size = new Size(186, 23);
            tbPrefixoMensagem.TabIndex = 3;
            // 
            // nQuantidade
            // 
            nQuantidade.Location = new Point(204, 30);
            nQuantidade.Name = "nQuantidade";
            nQuantidade.Size = new Size(45, 23);
            nQuantidade.TabIndex = 5;
            nQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // FPublisher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 368);
            Controls.Add(nQuantidade);
            Controls.Add(tbPrefixoMensagem);
            Controls.Add(btnEnviaMensagem);
            Controls.Add(lbMensagens);
            Controls.Add(lbPrefixoMensagem);
            Name = "FPublisher";
            Text = "Publisher";
            ((System.ComponentModel.ISupportInitialize)nQuantidade).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbPrefixoMensagem;
        private ListBox lbMensagens;
        private Button btnEnviaMensagem;
        private TextBox tbPrefixoMensagem;
        private NumericUpDown nQuantidade;
    }
}
