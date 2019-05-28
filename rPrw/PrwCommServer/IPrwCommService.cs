using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PrwCommServer
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IPrwCommService”。
    [ServiceContract]
    public interface IPrwCommService
    {
        [OperationContract]
        void DoWork();
         
 
        /// Basic functions, read and write
        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "Write/{streamLength}", BodyStyle = WebMessageBodyStyle.Bare)]
        string Write(string streamLength, Stream stream);

        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "Read/{streamLength}", BodyStyle = WebMessageBodyStyle.Bare)]
        string Read(string streamLength, Stream strem);


        // TODO: 在此添加您的服务操作
        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "UploadPrinterStatus/{streamLength}", BodyStyle = WebMessageBodyStyle.Bare)]
        string UploadPrinterStatus(string streamLength, Stream stream);


        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "DownloadPrinterCmd/{streamLength}", BodyStyle = WebMessageBodyStyle.Bare)]
        string DownloadPrinterCmd(string streamLength, Stream stream);


        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "UploadWareHouseStatus/{streamLength}", BodyStyle = WebMessageBodyStyle.Bare)]
        string UploadWareHouseStatus(string streamLength, Stream stream);


        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "DownloadWareHouseCmd/{streamLength}", BodyStyle = WebMessageBodyStyle.Bare)]
        string DownloadWareHouseCmd(string streamLength, Stream stream);

        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "UploadRobotStatus/{streamLength}", BodyStyle = WebMessageBodyStyle.Bare)]
        string UploadRobotStatus(string streamLength, Stream stream);


        [OperationContract, WebInvoke(Method = "POST", UriTemplate = "DownloadRobotCmd/{streamLength}", BodyStyle = WebMessageBodyStyle.Bare)]
        string DownloadRobotCmd(string streamLength, Stream stream);
    }
}
