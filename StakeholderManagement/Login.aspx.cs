using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLRMS;
using System.DirectoryServices;
using System.Data;
using System.Net;
using Microsoft.VisualBasic;

namespace StakeholderManagement
{


    public partial class Login : System.Web.UI.Page
    {
        private string _path;
        private string _filterAttribute;
        String strDisplayUserName;
        BLLSecurity objBLLSecurity = new BLLSecurity();
        private UserConfig objUserConfig = new UserConfig();
        // The coordinate watcher.
        private GeoCoordinateWatcher Watcher = null;
        string lat = "", lng = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsUserDetail;
                DataSet dsCheckUser;
                DataSet dsName;
                DataSet dsRetailerId;

                string UserCategory = "";
                string UsernameLowerCase = "";

                if (string.IsNullOrEmpty(txtUsesName.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(btnLogin, btnLogin.GetType(), "message", "alert('" + "Please enter Username" + "');", true);
                    txtUsesName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(btnLogin, btnLogin.GetType(), "message", "alert('" + "Please enter Password" + "');", true);
                    txtPassword.Focus();
                    return;
                }

                //---Convert to Lower case---
                UsernameLowerCase = Strings.LCase(txtUsesName.Text.Trim());


                //----Get user details by UserLoginId---
                dsUserDetail = objBLLSecurity.GetUserbyUserLoginId(UsernameLowerCase);

                if (dsUserDetail.Tables[0].Rows.Count != 0)
                {
                    dsCheckUser = objBLLSecurity.CheckUserLoginIdPwd(UsernameLowerCase, txtPassword.Text.Trim());

                    if (dsCheckUser.Tables[0].Rows.Count != 0)
                    {
                        if (dsUserDetail.Tables[0].Rows[0]["UserCategoryId"].ToString() != "")
                        {
                            UserCategory = dsUserDetail.Tables[0].Rows[0]["UserCategoryId"].ToString();
                            Session["UserCategoryId"] = UserCategory;
                            if ((bool)dsUserDetail.Tables[0].Rows[0]["Active"] != false)
                            {

                                Session["UserId"] = UsernameLowerCase.ToString();

                                dsName = objBLLSecurity.GetNamebyUserLoginId(Session["UserId"].ToString(), Convert.ToInt32(UserCategory));
                                if (dsName.Tables[0].Rows.Count != 0)
                                {
                                    Session["UserName"] = dsName.Tables[0].Rows[0]["Name"];
                                }

                                if (Convert.ToInt32(UserCategory) == 2)
                                {
                                    Session["CompanyId"] = dsName.Tables[0].Rows[0]["Id"];
                                }

                              
                                if (Convert.ToInt32(UserCategory) == 3)
                                {
                                    DataSet dsStakeholderType;
                                    dsStakeholderType = objBLLSecurity.GetStakeHolderTypeId(Session["UserId"].ToString());
                                    Session["HealthId"]= dsStakeholderType.Tables[0].Rows[0]["Id"];
                                    Session["FullName"] = dsStakeholderType.Tables[0].Rows[0]["FullName"];
                                    Session["StakeholderId"] = dsStakeholderType.Tables[0].Rows[0]["FitnessTypeId"];
                                }


                               
                                if (Convert.ToInt32(UserCategory) == 1)
                                {
                                    Session["Admin"] = dsName.Tables[0].Rows[0]["Id"];
                                    Session["StakeholderId"] = "0";
                                    Session["ASOAcc"] = "0";
                                    Session["HealthId"] = "0";
                                }


                             
                                if (Convert.ToInt32(UserCategory) == 1)
                                {

                                    Response.Redirect("Default.aspx");
                                }

                                if (Convert.ToInt32(UserCategory) == 2 || Convert.ToInt32(UserCategory) == 3)
                                {
                                    Response.Redirect("Default.aspx");
                                }


                                if (Convert.ToInt32(UserCategory) == 4)
                                {
                                    Response.Redirect("Default.aspx");
                                }


                                if (Convert.ToInt32(UserCategory) == 5)
                                {

                                    Response.Redirect(Server.UrlEncode("DisplayFeedback.aspx"));
                                }

                            }
                            else
                            {

                                Response.Redirect(Server.UrlEncode("~/Login.aspx"));

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(btnLogin, btnLogin.GetType(), "message", "alert('" + "Your Account has been Deactivated. Please contact the system administrator." + "');", true);
                            return;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(btnLogin, btnLogin.GetType(), "message", "alert('" + "Username or Password is incorrect." + "');", true);
                        txtPassword.Focus();
                        return;
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(btnLogin, btnLogin.GetType(), "message", "alert('" + "Invalid user.If you are a new user, please create an account." + "');", true);
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(btnLogin, btnLogin.GetType(), "message", "alert('" + "Error occured. Please contact the system administrator." + "');", true);
            }

        }

        private class GeoCoordinateWatcher
        {
        }

     
        protected void lblFPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect(Server.UrlEncode("ForgetPassword.aspx"));
        }

        protected void lblCreateAcc_Click(object sender, EventArgs e)
        {
            Response.Redirect(Server.UrlEncode("SignUp.aspx"));
        }



    }
}