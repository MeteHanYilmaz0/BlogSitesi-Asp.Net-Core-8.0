﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetList()
        {
           return _messageDal.GetListAll();
        }

        public List<Message> GetInBoxListByWriter(string p)
        {
            return _messageDal.GetListAll(x=>x.Receiver==p);
        }

        public void TAdd(Message t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message t)
        {
            throw new NotImplementedException();
        }

        public Message TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
        {
            throw new NotImplementedException();
        }

        List<Message2> IMessageService.GetInBoxListByWriter(string p)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }

        List<Message2> IGenericService<Message2>.GetList()
        {
            throw new NotImplementedException();
        }

        Message2 IGenericService<Message2>.TGetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
