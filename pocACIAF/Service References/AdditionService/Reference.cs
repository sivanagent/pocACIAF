﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pocACIAF.AdditionService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AdditionService.IAddition")]
    public interface IAddition {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddition/GetData", ReplyAction="http://tempuri.org/IAddition/GetDataResponse")]
        pocACIAF.AdditionService.GetDataResponse GetData(pocACIAF.AdditionService.GetDataRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddition/GetData", ReplyAction="http://tempuri.org/IAddition/GetDataResponse")]
        System.Threading.Tasks.Task<pocACIAF.AdditionService.GetDataResponse> GetDataAsync(pocACIAF.AdditionService.GetDataRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddition/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IAddition/GetDataUsingDataContractResponse")]
        pocACIAF.AdditionService.GetDataUsingDataContractResponse GetDataUsingDataContract(pocACIAF.AdditionService.GetDataUsingDataContractRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddition/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IAddition/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<pocACIAF.AdditionService.GetDataUsingDataContractResponse> GetDataUsingDataContractAsync(pocACIAF.AdditionService.GetDataUsingDataContractRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddition/AddUD", ReplyAction="http://tempuri.org/IAddition/AddUDResponse")]
        pocACIAF.AdditionService.AddUDResponse AddUD(pocACIAF.AdditionService.AddUDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddition/AddUD", ReplyAction="http://tempuri.org/IAddition/AddUDResponse")]
        System.Threading.Tasks.Task<pocACIAF.AdditionService.AddUDResponse> AddUDAsync(pocACIAF.AdditionService.AddUDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddition/AddArray", ReplyAction="http://tempuri.org/IAddition/AddArrayResponse")]
        pocACIAF.AdditionService.AddArrayResponse AddArray(pocACIAF.AdditionService.AddArrayRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAddition/AddArray", ReplyAction="http://tempuri.org/IAddition/AddArrayResponse")]
        System.Threading.Tasks.Task<pocACIAF.AdditionService.AddArrayResponse> AddArrayAsync(pocACIAF.AdditionService.AddArrayRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetData", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int value;
        
        public GetDataRequest() {
        }
        
        public GetDataRequest(int value) {
            this.value = value;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDataResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string GetDataResult;
        
        public GetDataResponse() {
        }
        
        public GetDataResponse(string GetDataResult) {
            this.GetDataResult = GetDataResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDataUsingDataContract", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDataUsingDataContractRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Addition.CompositeType composite;
        
        public GetDataUsingDataContractRequest() {
        }
        
        public GetDataUsingDataContractRequest(Addition.CompositeType composite) {
            this.composite = composite;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDataUsingDataContractResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetDataUsingDataContractResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Addition.CompositeType GetDataUsingDataContractResult;
        
        public GetDataUsingDataContractResponse() {
        }
        
        public GetDataUsingDataContractResponse(Addition.CompositeType GetDataUsingDataContractResult) {
            this.GetDataUsingDataContractResult = GetDataUsingDataContractResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddUD", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class AddUDRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Addition.MathData[] md;
        
        public AddUDRequest() {
        }
        
        public AddUDRequest(Addition.MathData[] md) {
            this.md = md;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddUDResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class AddUDResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Addition.MathData[] AddUDResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public Addition.MathData[] md;
        
        public AddUDResponse() {
        }
        
        public AddUDResponse(Addition.MathData[] AddUDResult, Addition.MathData[] md) {
            this.AddUDResult = AddUDResult;
            this.md = md;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddArray", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class AddArrayRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Addition.MathData[] md;
        
        public AddArrayRequest() {
        }
        
        public AddArrayRequest(Addition.MathData[] md) {
            this.md = md;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AddArrayResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class AddArrayResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public Addition.MathData[] AddArrayResult;
        
        public AddArrayResponse() {
        }
        
        public AddArrayResponse(Addition.MathData[] AddArrayResult) {
            this.AddArrayResult = AddArrayResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAdditionChannel : pocACIAF.AdditionService.IAddition, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AdditionClient : System.ServiceModel.ClientBase<pocACIAF.AdditionService.IAddition>, pocACIAF.AdditionService.IAddition {
        
        public AdditionClient() {
        }
        
        public AdditionClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AdditionClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdditionClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AdditionClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public pocACIAF.AdditionService.GetDataResponse GetData(pocACIAF.AdditionService.GetDataRequest request) {
            return base.Channel.GetData(request);
        }
        
        public System.Threading.Tasks.Task<pocACIAF.AdditionService.GetDataResponse> GetDataAsync(pocACIAF.AdditionService.GetDataRequest request) {
            return base.Channel.GetDataAsync(request);
        }
        
        public pocACIAF.AdditionService.GetDataUsingDataContractResponse GetDataUsingDataContract(pocACIAF.AdditionService.GetDataUsingDataContractRequest request) {
            return base.Channel.GetDataUsingDataContract(request);
        }
        
        public System.Threading.Tasks.Task<pocACIAF.AdditionService.GetDataUsingDataContractResponse> GetDataUsingDataContractAsync(pocACIAF.AdditionService.GetDataUsingDataContractRequest request) {
            return base.Channel.GetDataUsingDataContractAsync(request);
        }
        
        public pocACIAF.AdditionService.AddUDResponse AddUD(pocACIAF.AdditionService.AddUDRequest request) {
            return base.Channel.AddUD(request);
        }
        
        public System.Threading.Tasks.Task<pocACIAF.AdditionService.AddUDResponse> AddUDAsync(pocACIAF.AdditionService.AddUDRequest request) {
            return base.Channel.AddUDAsync(request);
        }
        
        public pocACIAF.AdditionService.AddArrayResponse AddArray(pocACIAF.AdditionService.AddArrayRequest request) {
            return base.Channel.AddArray(request);
        }
        
        public System.Threading.Tasks.Task<pocACIAF.AdditionService.AddArrayResponse> AddArrayAsync(pocACIAF.AdditionService.AddArrayRequest request) {
            return base.Channel.AddArrayAsync(request);
        }
    }
}
