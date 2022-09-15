using System;

namespace LightAssets 
{
    /// <summary>
    /// 处理资源 事件处理者接口
    /// </summary>
    public interface IEventHandler 
    {
        /// <summary>
        /// 资源校验开始事件。
        /// </summary>
        event EventHandler<ResourceVerifyStartEvent> ResourceVerifyStart;

        /// <summary>
        /// 资源校验成功事件。
        /// </summary>
        event EventHandler<ResourceVerifySuccessEvent> ResourceVerifySuccess;

        /// <summary>
        /// 资源校验失败事件。
        /// </summary>
        event EventHandler<ResourceVerifyFailureEvent> ResourceVerifyFailure;

        /// <summary>
        /// 资源应用开始事件。
        /// </summary>
        event EventHandler<ResourceApplyStartEvent> ResourceApplyStart;

        /// <summary>
        /// 资源应用成功事件。
        /// </summary>
        event EventHandler<ResourceApplySuccessEvent> ResourceApplySuccess;

        /// <summary>
        /// 资源应用失败事件。
        /// </summary>
        event EventHandler<ResourceApplyFailureEvent> ResourceApplyFailure;

        /// <summary>
        /// 资源更新开始事件。
        /// </summary>
        event EventHandler<ResourceUpdateStartEvent> ResourceUpdateStart;

        /// <summary>
        /// 资源更新改变事件。
        /// </summary>
        event EventHandler<ResourceUpdateChangedEvent> ResourceUpdateChanged;

        /// <summary>
        /// 资源更新成功事件。
        /// </summary>
        event EventHandler<ResourceUpdateSuccessEvent> ResourceUpdateSuccess;

        /// <summary>
        /// 资源更新失败事件。
        /// </summary>
        event EventHandler<ResourceUpdateFailureEvent> ResourceUpdateFailure;

        /// <summary>
        /// 资源更新全部完成事件。
        /// </summary>
        event EventHandler<ResourceUpdateAllCompleteEvent> ResourceUpdateAllComplete;
    }
}