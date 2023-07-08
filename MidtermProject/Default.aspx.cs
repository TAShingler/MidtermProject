/**
 *  Program:    MidtermProject
 *  Date:       December 16, 2021
 *  
 *  Link to piecewise function source: https://tomlinsonpsd.com/rates/rates-new-18/
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MidtermProject {
    public partial class _Default : Page {
        // constant string variable for line break
        private const string LnBr = "<br />";

        protected void Page_Load(object sender, EventArgs e) {
            // unused
        }

        // method that handles Click event for btnCalculate
        // method calculates the gallons used, fee owed for gallons used, tax owed for gallons used, and the bill total
        // calculated values are displayed to the user
        protected void btnCalculate_Click(object sender, EventArgs e) {
            // declare variables
            string fName, lName, initRdgString, finRdgString, taxPctString; // variables to hold user input
            double initRdg, finRdg, taxPct;                                 // variables for parsing
            double[] billValues = new double[4];                            // array to hold calculated values
            DateTime currentDate, periodFirstDay, periodLastDay;            // DateTime variables
            //TimeZoneInfo localZone = TimeZoneInfo.Local;                    // TimeZoneInfo variable

            // check for empty TextBoxes
            if (String.IsNullOrWhiteSpace(txtBoxFName.Text) || String.IsNullOrWhiteSpace(txtBoxLName.Text) || String.IsNullOrWhiteSpace(txtBoxInitRdg.Text) || 
                String.IsNullOrWhiteSpace(txtBoxFinRdg.Text) || String.IsNullOrWhiteSpace(txtBoxTax.Text)) {
                
                // error message if any TextBoxes on Form are empty
                //ScriptManager.RegisterStartupScript(
                //    this, 
                //    GetType(), 
                //    "script", 
                //    $"alert('Please make sure all fields are filled out');", 
                //    true);
                return; //exit method
            }

            // get and store user input
            fName = txtBoxFName.Text;           // first name
            lName = txtBoxLName.Text;           // last name
            initRdgString = txtBoxInitRdg.Text; // initial reading
            finRdgString = txtBoxFinRdg.Text;   // final reading
            taxPctString = txtBoxTax.Text;      // tax rate

            // parse user input
            // intial reading to double
            try {
                initRdg = double.Parse(initRdgString);
            } catch(FormatException ex) {
                // error message if user inputs value in an incorrect format
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "script",
                    $"alert('Please make sure a numerical value is entered for initial reading');",
                    true);
                return; //exit method
            }

            // final reading to double
            try {
                finRdg = double.Parse(finRdgString);
            } catch(FormatException ex) {
                // error message if user inputs value in an incorrect format
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "script",
                    $"alert('Please make sure a numerical value is entered for final reading');",
                    true);
                return; // exit method
            }

            // tax percent to double
            try {
                taxPct = double.Parse(taxPctString);

                // convert percent to decimal
                taxPct /= 100;  
            } catch(FormatException ex) {
                // error message if user inputs value in an incorrect format
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "script",
                    $"alert('Please make sure a numerical value is entered for tax rate');",
                    true);
                return; // exit method
            }

            // error message if value of final reading is less than value of initial reading
            if (finRdg < initRdg) {
                // error message
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "script",
                    $"alert('Please make sure the final reading is greater than or equal to the initial reading');",
                    true);
                return; // exit method;
            }

            // negative inital reading value
            if (initRdg < 0) {
                // error message
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "script",
                    $"alert('Please make sure the initial reading is not a negative number');",
                    true);
                return; // exit method;
            }

            // negative final reading value
            if (finRdg < 0) {
                // error message
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "script",
                    $"alert('Please make sure the final reading is not a negative number');",
                    true);
                return; // exit method;
            }

            // negative tax rate value
            if (taxPct < 0) {
                // error message
                ScriptManager.RegisterStartupScript(
                    this,
                    GetType(),
                    "script",
                    $"alert('Please make sure the tax rate is not a negative number');",
                    true);
                return; // exit method;
            }

            // perform calculations for user's bill
            billValues = CalculateBill(initRdg, finRdg, taxPct);

            // get date and time offset data
            DateTimeOffset dateTimeUSA = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, destinationTimeZoneId: "Eastern Standard Time");

            // convert date and time offset to DateTime object
            currentDate = dateTimeUSA.DateTime;
            periodLastDay = currentDate.AddDays(-1);    // subtract 1 day from today to make date and time for yesterday
            periodFirstDay = currentDate.AddDays(-31);  // subtract 30 days from yesterday to make date and time for beginning of bill period

            // display output with formatting for date/time, numerical values, and currency
            lblOutputGreeting.Text = $"Hello {fName} {lName},<br />" +
                $"This is your Water Bill Statement printed today: {currentDate:R}{TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time").GetUtcOffset(dateTimeUSA)} (Eastern Standard Time)";
            lblOutputCalcs.Text = "This bill covers the water usage from:<br />" +
                $"{periodFirstDay:ddd, dd MMM yyyy} to {periodLastDay:ddd, dd MMM yyyy} {LnBr}" +
                $"The initial reading on your water meter is {initRdg:N2} gallons {LnBr}" +
                $"The final reading on your water meter (as of yesterday) is {finRdg:N2} gallons {LnBr}" +
                $"The number of gallons used is {billValues[0]:N2} {LnBr}" +
                $"The basic fee for the number of gallons used is {billValues[1]:C2} {LnBr}" +
                $"The tax is {billValues[2]:C2} {LnBr}" +
                $"The total water bill is {billValues[3]:C2}";
            lblOutputThanks.Text = "Thank you for allowing us to serve you. We appreciate your payment.";
        }

        // method that handles Click event for btnReset, clears all TextBox text and clears text for all output Labels
        protected void btnReset_Click(object sender, EventArgs e) {
            // reset TextBoxes
            txtBoxFName.Text = "";
            txtBoxLName.Text = "";
            txtBoxInitRdg.Text = "";
            txtBoxFinRdg.Text = "";
            txtBoxTax.Text = "";

            // reset output Labels
            lblOutputGreeting.Text = "";
            lblOutputCalcs.Text = "";
            lblOutputThanks.Text = "";
        }

        // method that calculates gallons used, fee owed for gallons used, tax owed for gallons used, and total for the bill based on the initial reading, final reading, and tax rate values passed
        // to the method
        private double[] CalculateBill(double initRdg, double finRdg, double taxPct) {
            // declare variables
            double gallonsUsed, taxOwed, feeOwed, billTotal;
                
            // perform calculations
            gallonsUsed = finRdg - initRdg;
            feeOwed = CalculateFee(gallonsUsed);
            taxOwed = CalculateTaxOwed(feeOwed, taxPct);
            billTotal = feeOwed + taxOwed;

            // return calculated values
            return new double[] { gallonsUsed, feeOwed, taxOwed, billTotal};
        }

        // method that calculates the fee owed based on gallons used
        // fee is calculate using a piecewise function
        private double CalculateFee(double gallonsUsed) {
            // instantiate variables
            double amountOwed = 0;

            // perform calculations USING A PIECEWISE FUNCTION
            if (gallonsUsed >= 0 && gallonsUsed <= 3000) { amountOwed = 0.01234 * gallonsUsed; } 
            else if (gallonsUsed > 3000 && gallonsUsed <= 6000) { amountOwed = (0.00867 * gallonsUsed) + 11.01; } 
            else if (gallonsUsed > 6000 && gallonsUsed <= 10000) { amountOwed = (0.00833 * gallonsUsed) + 13.05; } 
            else if (gallonsUsed > 10000 && gallonsUsed <= 20000) { amountOwed = (0.00791 * gallonsUsed) + 17.25; } 
            else if (gallonsUsed > 20000) { amountOwed = (0.00786 * gallonsUsed) + 18.25; }

            // return fee owed based on gallons used, rounded to 2 decimal places
            return Math.Round(amountOwed, 2);
        }

        // calculate taxes owed on fee for gallons used to 2 decimal places
        private double CalculateTaxOwed(double feeOwed, double taxPct) {
            return Math.Round((feeOwed * taxPct), 2);   // return taxes owed
        }
    }
}