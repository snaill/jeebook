using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jeebook.ROA
{
     public class HttpStatusCode
     {
        public const int HTTP_100_Continue = 100;     
        public const int HTTP_101_SwitchingProtocols = 101;
        public const int HTTP_200_OK = 200;
        public const int HTTP_201_Created = 201;
        public const int HTTP_202_Accepted = 202;
        public const int HTTP_203_Non_AuthoritativeInformation = 203;
        public const int HTTP_204_NoContent = 204;
        public const int HTTP_205_ResetContent = 205;
        public const int HTTP_206_PartialContent = 206;
        public const int HTTP_207_Multi_Status = 207;
        public const int HTTP_300_MultipleChoices = 300;
        public const int HTTP_301_MovedPermanently = 301;
        public const int HTTP_302_Found = 302;
        public const int HTTP_303_SeeOther = 303;
        public const int HTTP_304_NotModified = 304;
        public const int HTTP_305_UseProxy = 305;
        public const int HTTP_306_SwitchProxyUnused = 306;
        public const int HTTP_307_TemporaryRedirect = 307;
        public const int HTTP_400_BadRequest = 400;
        public const int HTTP_401_Unauthorized = 401;
        public const int HTTP_402_PaymentRequired = 402;
        public const int HTTP_403_Forbidden = 403;
        public const int HTTP_404_NotFound = 404;
        public const int HTTP_405_MethodNotAllowed = 405;
        public const int HTTP_406_NotAcceptable = 406;
        public const int HTTP_407_ProxyAuthenticationRequired = 407;
        public const int HTTP_408_RequestTimeout = 408;
        public const int HTTP_409_Conflict = 409;
        public const int HTTP_410_Gone = 410;
        public const int HTTP_411_LengthRequired = 411;
        public const int HTTP_412_PreconditionFailed = 412;
        public const int HTTP_413_RequestEntityTooLarge = 413;
        public const int HTTP_414_Request_URITooLong = 414;
        public const int HTTP_415_UnsupportedMediaType = 415;
        public const int HTTP_416_RequestedRangeNotSatisfiable = 416;
        public const int HTTP_417_ExpectationFailed = 417;
        public const int HTTP_500_InternalServerError = 500;
        public const int HTTP_501_NotImplemented = 501;
        public const int HTTP_502_BadGateway = 502;
        public const int HTTP_503_ServiceUnavailable = 503;
        public const int HTTP_504_GatewayTimeout = 504;
        public const int HTTP_505_HTTPVersionNotSupported = 505;
    };
}
