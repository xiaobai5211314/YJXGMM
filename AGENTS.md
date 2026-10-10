# 一键修改账户名密码 (YJXGMM)

## 1. 项目概述
Windows 本地账户管理小工具，支持管理员权限下一键重命名当前登录账户及重置本地账户密码。
- 技术栈：C# WinForms (.NET Framework 4.8)、WMI (`System.Management`)、`System.DirectoryServices.AccountManagement`。

## 2. 项目结构
- `Program.cs`：程序主入口。
- `Form1.cs`：主窗体业务逻辑（事件响应、WMI 改名与账号密码调用）。
- `Form1.Designer.cs`：设计器生成的窗体控件定义。
- `Form1.resx`：窗体图标与嵌入二进制资源。
- `app.manifest`：Windows 应用程序清单（声明 `requireAdministrator` 提权）。
- `一键修改账户名密码.csproj` / `一键修改账户名密码.sln`：项目与解决方案文件。
- `password.dat`：运行时生成的密码记录文件（存放在 exe 所在目录）。

## 3. 开发约定
- 框架版本：锁定为 .NET Framework 4.8。
- 依赖包声明：必须在 csproj 中引用 `System.Resources.Extensions` NuGet 包，以正确解析 `Form1.resx` 嵌入图标资源。

## 4. 核心业务规则
- **提权强制约束**：WMI 改名与本地用户密码修改必须具备管理员权限，`app.manifest` 必须保持 `requireAdministrator`。
- **改名与改密生命周期**：
  - 改账户名基于 `Win32_UserAccount.Rename`，需电脑重启后系统完全生效。
  - 改密码基于 `PrincipalContext` + `UserPrincipal`，立即生效。
- **密码隐私与本地记录**：
  - Windows 系统不提供回显当前登录明文密码的接口，界面“当前密码”仅显示本工具此前持久化在 `password.dat` 中的记录。

## 5. 构建与运行
- **MSBuild 编译**（推荐使用 MSBuild 处理资源）：
  ```powershell
  & "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\amd64\MSBuild.exe" .\一键修改账户名密码.csproj /restore /p:Configuration=Release
  ```
  产物位于 `bin\Release\一键修改账户名密码.exe`。

## 6. 测试与验证
- 验证方式：
  1. 编译后以管理员身份运行生成的 exe。
  2. 检查当前账户名是否正确读取并填入 `textBox3`。
  3. 测试重命名提示与改密交互。

## 7. 修改注意事项
- 避免使用裸 `dotnet build` 处理本项目的资源文件，.NET SDK 对 .NET Framework 4.8 WinForms resx 资源处理存在兼容限制。

## 8. 相关文档
- [README.md](file:///e:/OneDrive%20-%201301173082@stu.ahcme.edu.cn/OneDrive%20-%20stu.ahcme.edu.cn/%E5%B0%8F%E7%99%BD/%E7%A8%8B%E5%BA%8F/%E6%A0%A1%E6%8B%9B2022/%E4%B8%80%E9%94%AE%E4%BF%AE%E6%94%B9%E8%B4%A6%E6%88%B7%E5%90%8D%E5%AF%86%E7%A0%81/README.md)
