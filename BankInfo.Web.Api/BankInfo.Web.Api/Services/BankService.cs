using BankInfo.Web.Api.Data;
using BankInfo.Web.Api.Models;
using BankInfo.Web.Api.Services;
using DevExpress.Entity.Model.Metadata;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IMapper = AutoMapper.IMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Linq;

namespace BankInfo.Web.Api.services
{
    public class BankService : IBankService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public BankService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        

        public async Task<ServiceResponse<List<Models.BankInfo>>> CreateBankInfo(Models.BankInfo newBank)
        {

            
            ServiceResponse<List<Models.BankInfo>> response = new ServiceResponse<List<Models.BankInfo>>();
            Models.BankInfo bank = _mapper.Map<Models.BankInfo>(newBank);
            await _context.BankInfos.AddAsync(bank);
            await _context.SaveChangesAsync();

            response.Data = (_context.BankInfos.Select(c => _mapper.Map<Models.BankInfo>(c))).ToList();
            response.Success = true;
            response.Message = "acc has been created";

            return response;

        }


        public async Task<ServiceResponse<List<Models.BankInfo>>> DeleteBankInfo(int bankId)
        {
            ServiceResponse<List<Models.BankInfo>> response = new ServiceResponse<List<Models.BankInfo>>();
            try { Models.BankInfo bank = await _context.BankInfos.FirstOrDefaultAsync(c=>c.Id==bankId);
                if (bank != null)
                {
                    _context.BankInfos.Remove(bank);
                    await _context.SaveChangesAsync();
                    response.Data=(_context.BankInfos.Where(c=>c.Id == bankId)).Select(c=>_mapper.Map<Models.BankInfo>(c)).ToList();
                    response.Success=true;
                    response.Message = "deleted";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Character Not Found";
                }




            }
            
            catch (Exception ex)
            {
                response.Success=true;
                response.Message=ex.Message;    

            }
            
           
         return response;
        }

        public async Task<ServiceResponse<List<Models.BankInfo>>> GetAllBankInfo()
        {
            ServiceResponse<List<Models.BankInfo>> response =new ServiceResponse<List<Models.BankInfo>>();  
            List<Models.BankInfo> dbbankInfos=await _context.BankInfos.ToListAsync();


            response.Data = (_context.BankInfos.Select(c => _mapper.Map<Models.BankInfo>(c))).ToList();

            return response;

        }

        public async Task<ServiceResponse<List<Models.BankInfo>>> UpdateBankInfo(Models.BankInfo bankId)
        {
            ServiceResponse<List<Models.BankInfo>> response = new ServiceResponse<List<Models.BankInfo>>();
            try
            {

                Models.BankInfo bankInfo = await _context.BankInfos.Where(c => c.Id==bankId.Id).FirstOrDefaultAsync(c => c.Id == bankId.Id);
                if(bankInfo.Id==bankId.Id)
                {
                    bankInfo.Id = bankId.Id;
                    bankInfo.Name=bankId.Name;
                    bankInfo.Amount=bankId.Amount;
                    bankInfo.Currency = bankId.Currency;
                    _context.BankInfos.Update(bankInfo);
                    await _context.SaveChangesAsync();
                    
                    response.Success = true;
                    response.Message = "Account has been changed";
                }
                else
                {
                    response.Success= false;
                    response.Message = "Character not found";
                }
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message=ex.Message;
            }
            return response;
        }
    }

       
     
    }

