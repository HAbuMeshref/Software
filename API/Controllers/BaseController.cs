using Service.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Domain.Common;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers
{

    [ApiController]
    public class BaseController : Controller
    {
        private readonly IConfiguration _configuration;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;


        public BaseController(IServiceUnitOfWork serviceUnitOfWork,
            IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _serviceUnitOfWork = serviceUnitOfWork;


            #region ~Read From ClaimIdentity~
            if (_httpContextAccessor.HttpContext.Request.Headers != null)
            {
                var authToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
                var SysCode = _httpContextAccessor.HttpContext.Request.Headers["SystemCode"].FirstOrDefault();
                var ModCode = _httpContextAccessor.HttpContext.Request.Headers["ModuleCode"].FirstOrDefault();

                if (!string.IsNullOrEmpty(authToken))
                {
                    string output = authToken.Substring("Bearer".Length).Trim();
                   // _tPServiceUnitOfWork.TPIntegrationService.Value.AuthToken = output;
                }

                //_tPServiceUnitOfWork.TPIntegrationService.Value.SystemCode = SysCode;
                //  _tPServiceUnitOfWork.TPIntegrationService.Value.ModuleCode = ModCode;
                var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                var claim = (identity).FindFirst(ClaimTypes.UserData);
                //LoginDTO loginDTO = new LoginDTO();
                //if (claim != null)
                //{
                //    var userInfo = claim.Value;
                //    loginDTO = JsonConvert.DeserializeObject<LoginDTO>(userInfo);

                //}



            }
            #endregion



            //#region Read From ClaimIdentity
            //if (_httpContextAccessor != null && _httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.User != null &&
            //   _httpContextAccessor.HttpContext.User.Identity != null)
            //{

            //    var authToken = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            //    if (!string.IsNullOrEmpty(authToken))
            //    {
            //        string output = authToken.Substring("Bearer ".Length).Trim();
            //        //tPServiceUnitOfWork.TPIntegrationService.Value.AuthToken = output;
            //        SharedSettings.token = output;
            //    }

            //    var jwt = new JwtSecurityTokenHandler().ReadToken(SharedSettings.token) as JwtSecurityToken;
            //    var Newclaims = jwt?.Claims?.ToList();

            //    var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            //    IList<Claim> claims = identity.Claims.ToList();
            //    if (claims.Count > 0)
            //    {



            //    }
            //}
            //#endregion
        }


    }
}
