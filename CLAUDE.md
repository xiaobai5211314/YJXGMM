# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## 编译

```powershell
# 使用 MSBuild 编译（dotnet build 处理 .NET Framework 4.8 WinForms 资源时有问题）
& "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\amd64\MSBuild.exe" .\一键修改账户名密码.csproj /restore /p:Configuration=Debug
```

输出路径：`bin\Debug\一键修改账户名密码.exe`

项目需要 `System.Resources.Extensions` NuGet 包（csproj 中以 PackageReference 声明），因为 `Form1.resx` 嵌入了图标二进制资源。

## 架构

单窗体 WinForms 应用（.NET Framework 4.8），用于管理当前 Windows 本地账户。

**核心流程：**
- `Program.cs` → 入口，启动 `Form1`
- `Form1.cs` → 全部业务逻辑，集中在事件处理器中
- `Form1.Designer.cs` → 自动生成的布局（4 个 TextBox、4 个 Label、2 个 Button）
- `password.dat` → 运行时配置文件，存储上次设置的密码（创建在 exe 同目录下）

**关键 API：**
- `System.Management.ManagementObject` + `Win32_UserAccount.Rename` — 重命名本地用户（需重启）
- `System.DirectoryServices.AccountManagement.PrincipalContext` + `UserPrincipal` — 修改密码（立即生效）

**UI 控件映射**（定义在 Form1.Designer.cs）：
- `textBox1` = 新账户名输入框，`textBox2` = 新密码输入框
- `textBox3` = 当前账户名显示，`textBox4` = 已保存密码显示
- `button1` → `button1_Click`（改账户名），`button2` → `button2_Click`（改密码）

## 重要约束

- 必须以管理员身份运行（WMI 改名和密码重置都需要提权）
- Windows 不提供读取当前登录密码的 API — `textBox4` 只显示本工具之前保存到 `password.dat` 的密码
- 修改账户名后必须重启；修改密码立即生效
