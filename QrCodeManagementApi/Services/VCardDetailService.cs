﻿using QrCodeManagementApi.EntityManager.DbAccess;
using QrCodeManagementApi.EntityManager.DbEntity;

namespace QrCodeManagementApi.Services
{
    public class VCardDetailService : IVCardDetailService
    {
        private readonly IVCardDetailManager _vCardDetailManager;
        /// <summary>
        /// The constructor is used for the production environment.
        /// </summary>
        public VCardDetailService()
            : this(null)
        {
        }

        /// <summary>
        /// The constructor is used for Unit Testing & DI Container.
        /// </summary>
        /// <param name="vCardDetailManager"></param>
        public VCardDetailService(IVCardDetailManager vCardDetailManager)
        {
            _vCardDetailManager = vCardDetailManager ?? new VCardDetailManager();
        }
        public bool InsertVCardDetail(VCardDetail vCardDetailModel)
        {
            // Make sure only one QRCode with one VCard
            if (_vCardDetailManager.GetByQrId(vCardDetailModel.QrId) != null)
            {
                return false;
            }

            return _vCardDetailManager.Insert(vCardDetailModel);
        }

        public bool DeleteVCardDetailById(int id)
        {
            return _vCardDetailManager.Delete(id);
        }

        public bool UpdateVCardDetail(VCardDetail vCardDetailModel)
        {
            VCardDetail vCardDetail = _vCardDetailManager.GetByQrId(vCardDetailModel.QrId);

            if (vCardDetail != null)
            {
                vCardDetail.City = vCardDetailModel.City;
                vCardDetail.Company = vCardDetailModel.Company;
                vCardDetail.Country = vCardDetailModel.Country;
                vCardDetail.Email = vCardDetailModel.Email;
                vCardDetail.Fax = vCardDetailModel.Fax;
                vCardDetail.FirstName = vCardDetailModel.FirstName;
                vCardDetail.JobTitle = vCardDetailModel.JobTitle;
                vCardDetail.LastName = vCardDetailModel.LastName;
                vCardDetail.MobileNumber = vCardDetailModel.MobileNumber;
                vCardDetail.Phone = vCardDetailModel.Phone;
                vCardDetail.State = vCardDetailModel.State;
                vCardDetail.Street = vCardDetailModel.Street;
                vCardDetail.Website = vCardDetailModel.Website;
                vCardDetail.Zipcode = vCardDetailModel.Zipcode;
                vCardDetail.ProfileImage = vCardDetailModel.ProfileImage;
                vCardDetail.About = vCardDetailModel.About;
                vCardDetail.HeaderColor = vCardDetailModel.HeaderColor;
                vCardDetail.ButtonColor = vCardDetailModel.ButtonColor;
                vCardDetail.WelcomeScreenImage = vCardDetailModel.WelcomeScreenImage;
                vCardDetail.TaxIdentificationNumber = vCardDetailModel.TaxIdentificationNumber;
                vCardDetail.SocialMediaWebsite = vCardDetailModel.SocialMediaWebsite;
                vCardDetail.SocialMediaFacebook = vCardDetailModel.SocialMediaFacebook;
                vCardDetail.SocialMediaTwitter = vCardDetailModel.SocialMediaTwitter;
                vCardDetail.SocialMediaInstagram = vCardDetailModel.SocialMediaInstagram;
                vCardDetail.SocialMediaSnapchat = vCardDetailModel.SocialMediaSnapchat;
                vCardDetail.SocialMediaYouTube = vCardDetailModel.SocialMediaYouTube;
                vCardDetail.SocialMediaPinterest = vCardDetailModel.SocialMediaPinterest;
                vCardDetail.SocialMediaGooglePlus = vCardDetailModel.SocialMediaGooglePlus;
                vCardDetail.SocialMediaLinkedIn = vCardDetailModel.SocialMediaLinkedIn;
                vCardDetail.SocialMediaXing = vCardDetailModel.SocialMediaXing;
                vCardDetail.SocialMediaFlickr = vCardDetailModel.SocialMediaFlickr;
                vCardDetail.SocialMediaVimeo = vCardDetailModel.SocialMediaVimeo;
                vCardDetail.SocialMediaVKontakte = vCardDetailModel.SocialMediaVKontakte;
                vCardDetail.SocialMediaSkype = vCardDetailModel.SocialMediaSkype;
                vCardDetail.SocialMediaWeChat = vCardDetailModel.SocialMediaWeChat;

                return _vCardDetailManager.Update(vCardDetail);
            }

            return false;
        }

        public VCardDetail GetVCardDetailById(int id)
        {
            return _vCardDetailManager.GetById(id);
        }

        public VCardDetail GetVCardDetailByQrId(string qrId)
        {
            return _vCardDetailManager.GetByQrId(qrId);
        }
    }
}