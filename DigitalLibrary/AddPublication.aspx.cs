﻿using DigitalLibrary.Models;
using DigitalLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DigitalLibrary
{
    public partial class AddPublication : System.Web.UI.Page
    {
        public int PublicationId
        {
            get
            {
                return Convert.ToInt32(ViewState["PublicationId"]);
            }
            set
            {
                ViewState["PublicationId"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllPublication();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            if (PublicationId >0)
            {
                lblMsg.Text = string.Empty;
                UpdatePublication();
                btnSave.Text = "Add Publication";
                txtPublicationName.Text = string.Empty;
                GetAllPublication();
            }
            else
            {
                lblMsg.Text = string.Empty;
                string Name = txtPublicationName.Text;
                InsertPublication(Name);
                txtPublicationName.Text = string.Empty;
                GetAllPublication();
            }

        }

        protected void gvPublication_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                PublicationId = 0;
                int intPublicationId = Convert.ToInt32(e.CommandArgument);
                GetPublicationById(intPublicationId);
                btnSave.Text = "Update Publication";
                PublicationId = intPublicationId;


            }
            else if (e.CommandName == "delete")
            {
                lblMsg.Text = string.Empty;
                int intPublicationId = Convert.ToInt32(e.CommandArgument);
                DeletePublicationById(intPublicationId);
                GetAllPublication();

            }
        }

        protected void gvPublication_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvPublication_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        private void GetAllPublication()
        {
            List<PublicationModel> lstPublication = new List<PublicationModel>();
            PublicationService objPublicationService = new PublicationService();
            try
            {

                lstPublication = objPublicationService.GetAllPublication();
                gvPublication.DataSource = lstPublication;
                gvPublication.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        private void InsertPublication(string publicationName)
        {
            int i = 0;
            try
            {
                PublicationService publication = new PublicationService();
                i = publication.InsertPublication(publicationName);
                if (i > 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.GhostWhite;
                    lblMsg.Text = "Publication Added SuccessFully.";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.IndianRed;
                    lblMsg.Text = "Error Occured.";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void DeletePublicationById(int PublicationId)
        {
            int i = 0;
            PublicationService publicationService = new PublicationService();
            i = publicationService.DeletePublicationById(PublicationId);

            if (i > 0)
            {
                lblMsg.ForeColor = System.Drawing.Color.GhostWhite;
                lblMsg.Text = "Publication Deleted SuccessFully.";
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.IndianRed;
                lblMsg.Text = "Error Occured.";
            }
        }

        private void GetPublicationById(int PublicationId)
        {
            PublicationService publicationService = new PublicationService();
            PublicationModel publicationModel = new PublicationModel();
            publicationModel = publicationService.GetPublicationById(PublicationId);
            if (publicationModel != null)
            {
                txtPublicationName.Text = publicationModel.PublicationName;
            }
        }

        private void UpdatePublication()
        {
            PublicationModel publicationModel = new PublicationModel();
            PublicationService publicationService = new PublicationService();
            int i = 0;
            try
            {
                publicationModel.PublicationName = txtPublicationName.Text;
                publicationModel.PublicationId = PublicationId;

                i = publicationService.UpdatePublication(publicationModel);
                if (i > 0)
                {
                    lblMsg.ForeColor = System.Drawing.Color.GhostWhite;
                    lblMsg.Text = "Publication Updated SuccessFully.";
                }
                else
                {
                    lblMsg.ForeColor = System.Drawing.Color.IndianRed;
                    lblMsg.Text = "Error Occured.";
                }
            }
            catch (Exception ex) { 
            }
           

        }
    }
}