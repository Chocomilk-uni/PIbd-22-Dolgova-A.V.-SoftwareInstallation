using SoftwareInstallationBusinessLogic.BindingModels;
using SoftwareInstallationBusinessLogic.Interfaces;
using SoftwareInstallationBusinessLogic.ViewModels;
using SoftwareInstallationFileImplement.Models;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareInstallationFileImplement.Implementations
{
    public class MessageInfoStorage : IMessageInfoStorage
    {
        private readonly FileDataListSingleton source;

        public MessageInfoStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public List<MessageInfoViewModel> GetFullList()
        {
            return source.MessageInfos
                .Select(CreateModel)
                .ToList();
        }

        public List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            if (model.ToSkip.HasValue && model.ToTake.HasValue && !model.ClientId.HasValue)
            {
                return source.MessageInfos.Skip((int)model.ToSkip).Take((int)model.ToTake)
                .Select(CreateModel).ToList();
            }
            return source.MessageInfos
            .Where(rec => (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
            (!model.ClientId.HasValue && rec.DateDelivery.Date == model.DateDelivery.Date))
            .Skip(model.ToSkip ?? 0)
            .Take(model.ToTake ?? source.MessageInfos.Count())
            .Select(CreateModel)
            .ToList();
        }

        public void Insert(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return;
            }

            source.MessageInfos.Add(CreateModel(model, new MessageInfo()));
        }


        private MessageInfo CreateModel(MessageInfoBindingModel model, MessageInfo message)
        {
            message.ClientId = model.ClientId;
            message.SenderName = source.Clients.FirstOrDefault(rec => rec.Id == model.ClientId)?.ClientFIO;
            message.DateDelivery = model.DateDelivery;
            message.Subject = model.Subject;
            message.Body = model.Body;
            return message;
        }

        private MessageInfoViewModel CreateModel(MessageInfo message)
        {
            return new MessageInfoViewModel
            {
                MessageId = message.MessageId,
                SenderName = message.SenderName,
                DateDelivery = message.DateDelivery,
                Subject = message.Subject,
                Body = message.Body
            };
        }
    }
}