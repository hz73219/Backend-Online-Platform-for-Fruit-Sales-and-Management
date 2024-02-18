using AutoMapper;
using Model.Entities;
using Repository.Interface;
using Service.Base;
using Service.DTO;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implement
{
    public class VoucherService : BaseService<Voucher, VoucherDto, IVoucherRepo>, IVoucherService
    {
        public VoucherService(IVoucherRepo repo, IMapper mapper) : base(repo, mapper)
        {
        }
        public override void Create(Voucher entity)
        {
            try
            {
                var voucher = this.ThisRepo._dbSet.Where(x=>x.Name==entity.Name).FirstOrDefault();
                if (voucher==null)
                {
                    ThisRepo.Create(entity);
                }
                else
                {
                    Flag = false;

                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }
        }
        public override void Get(string id)
        {
            try
            {
                var voucher = this.ThisRepo._dbSet.Where(x => x.Name == id&&x.isUse==false&&x.Expired_Time>=DateTime.Now).FirstOrDefault();
                if (voucher == null)
                {
                    Flag = false;

                }
                else
                {
                    this.ObjDetail = voucher;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }

        }
        public override void GetAll()
        {
            try
            {
                this.ObjList = this.ThisRepo._dbSet.Where(x => x.isUse == false && x.Expired_Time >= DateTime.Now).ToList();           
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                Flag = false;
            }

        }
    }
}
