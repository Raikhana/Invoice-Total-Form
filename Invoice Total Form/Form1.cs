using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice_Total_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        decimal discountPercent;
        int numberOfInvoices;
        decimal totalOfInvoices;
        int price;
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string customer = cmbEnterCustomerType.Text;
            string product = cmbEnterProduct.Text;
            string size = cmbSize.Text;
            int amount = Convert.ToInt32(txtAmount.Text);
            
            if (product == "pizza") 
            {
                if (size == "Small")
                    price = 20;
                else if (size == "Medium")
                    price = 25;
                else if(size == "Large")
                    price = 30;
            }
            else if (product == "burger")
            {
                if (size == "Small")
                    price = 15;
                else if (size == "Medium")
                    price = 20;
                else if (size == "Large")
                    price = 25;
            }
            else
            {
                if (size == "Small")
                    price = 10;
                else if (size == "Medium")
                    price = 20;
                else if (size == "Large")
                    price = 30;
            }
            int subtotal = price * amount;
            txtSubtotal.Text = subtotal.ToString();

            if (customer == "R")
            {
                if (subtotal >= 10 && subtotal < 25) 
                    discountPercent = .0m;
                else if (subtotal >= 25 && subtotal < 45)
                    discountPercent = .1m;
                else if (subtotal >= 50 && subtotal < 75)
                    discountPercent = .25m;
            }
            else if (customer == "C")
            {
                if (subtotal < 85)
                    discountPercent = .2m;
                else
                    discountPercent = .3m;
            }
            else
            {
                discountPercent = .4m;
            }

            decimal discountAmount = subtotal * discountPercent;
            decimal total = subtotal - discountAmount;

            txtDiscoutnPersent.Text = discountPercent.ToString();
            txtDiscountAmount.Text = discountAmount.ToString();
            txtTotal.Text = total.ToString();

            numberOfInvoices++;
            totalOfInvoices += total;
            cmbEnterCustomerType.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtNumberOfInvoices.Text = numberOfInvoices.ToString();
            txtTotalOfInvoices.Text = totalOfInvoices.ToString();
            cmbEnterCustomerType.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbEnterCustomerType.Text = "";
            cmbEnterProduct.Text = "";
            cmbSize.Text = "";
            txtAmount.Text = "";
            txtSubtotal.Text = "";
            txtDiscoutnPersent.Text = "";
            txtDiscountAmount.Text = "";
            txtTotal.Text = "";
            txtNumberOfInvoices.Text = "";
            txtTotalOfInvoices.Text = "";
            numberOfInvoices = 0;
            totalOfInvoices = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
