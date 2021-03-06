using System;
using System.Collections.Generic;
using System.Text;

namespace GFFramework.ScreenView
{
    /// <summary>
    /// IScreenView接口
    /// </summary>
    public interface IScreenView
    {
        /// <summary>
        /// IScreenView名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// IScreenView是否加载
        /// </summary>
        bool IsLoad { get;  }
        /// <summary>
        /// IScreenView 初始化
        /// </summary>
        void BeginInit(); 
        /// <summary>
        /// IScreenView 退出
        /// </summary>
        void BeginExit(); 
        void Update(float delta); 
        void FixedUpdate(float delta);
    }
}