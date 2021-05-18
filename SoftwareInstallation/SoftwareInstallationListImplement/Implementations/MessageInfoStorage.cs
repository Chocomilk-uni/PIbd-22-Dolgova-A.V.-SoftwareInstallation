using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.Interfaces;
using SoftwareInstallationBusinessLogic.ViewModels;
using SoftwareInstallationListImplement.Models;
using System.Collections.Generic;

namespace SoftwareInstallationListImplement.Implementations
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly DataListSingleton source;

        public MessageInfoStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();

            foreach (var messageInfo in source.MessageInfos)
            {
                result.Add(CreateModel(messageInfo));
            }
            return result;
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            List<MessageInfoViewModel> result = new List<MessageInfoViewModel>();

            foreach (var messageInfo in source.MessageInfos)
            {
                if ((model.ClientId.HasValue && messageInfo.ClientId == model.ClientId) 
                    || (!model.ClientId.HasValue && messageInfo.DateDelivery.Date == model.DateDelivery.Date))
                {
                    result.Add(CreateModel(messageInfo));
                }
            }
            if (result.Count > 0)
            {
                return result;
            }
            return null;
        }

        public void Insert(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return;
            }

            source.MessageInfos.Add(CreateModel(model, new MessageInfo()));
        }

        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo messageInfo)
        {
            string clientName = string.Empty;
            foreach (var client in source.Clients)
            {

                if (client.Id == model.ClientId)
                {
                    clientName = client.ClientFIO;
                    break;
                }
            }

            messageInfo.MessageId = model.MessageId;
            messageInfo.SenderName = clientName;
            messageInfo.Subject = model.Subject;
            messageInfo.Body = model.Body;
            messageInfo.DateDelivery = model.DateDelivery;

            return messageInfo;
        }

        private MessageInfoViewModel CreateModel(MessageInfo messageInfo)
        {
            return new MessageInfoViewModel
            {
                MessageId = messageInfo.MessageId,
                SenderName = messageInfo.SenderName,
                Subject = messageInfo.Subject,
                Body = messageInfo.Body,
                DateDelivery = messageInfo.DateDelivery
            };
        }
    }
}