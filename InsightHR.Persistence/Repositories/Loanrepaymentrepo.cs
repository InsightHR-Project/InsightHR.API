using Dapper;
using InsightHR.Application.Interfaces;
using InsightHR.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightHR.Persistence.Repositories
{
    public class Loanrepaymentrepo : IloanRepayments
    {
        private readonly DapperContext _dapperContext;

        public Loanrepaymentrepo(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<dynamic>> GetAllAsync(int userId)
        {
          using var conn = _dapperContext.CreateConnection();

            var param = new DynamicParameters();
            param.Add("@user_Id", userId);

            var res = await conn.QueryAsync<dynamic>(
                "sp_auto_loan_repayment",
                param,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return res;

        }
    }
}
