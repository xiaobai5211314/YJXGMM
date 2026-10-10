# 一键修改账户名密码

Windows 本地账户管理小工具，支持一键修改当前登录账户的用户名和密码。

## 功能

- **修改账户名** — 通过 WMI 重命名当前 Windows 用户，修改后需重启生效
- **修改密码** — 通过 `DirectoryServices.AccountManagement` 设置新密码，立即生效
- **密码记录** — 修改密码后自动保存到本地配置文件，下次启动时显示

## 技术栈

- C# WinForms (.NET Framework 4.8)
- `System.Management` — WMI 操作（重命名用户）
- `System.DirectoryServices.AccountManagement` — 本地账户密码管理

## 使用方法

1. 以**管理员身份**运行程序
2. 左侧输入新账户名，点击"修改账户"（会提示重启）
3. 右侧输入新密码，点击"修改密码"（立即生效）
4. 下方"当前密码"框显示上次通过本工具设置的密码

## 注意事项

- 需要管理员权限运行
- 修改账户名后必须重启电脑才能完全生效
- 密码记录存储在程序目录下的 `password.dat` 中，仅记录通过本工具修改的密码
- Windows 不提供读取当前登录密码的 API，"当前密码"显示的是本工具上次保存的记录

## 项目结构

```
├── Form1.cs                  # 主窗体逻辑
├── Form1.Designer.cs         # 窗体布局（设计器生成）
├── Program.cs                # 程序入口
├── Properties/
│   └── AssemblyInfo.cs       # 程序集信息
└── 一键修改账户名密码.csproj   # 项目文件
```

## 编译

使用 Visual Studio 打开 `.sln` 或 `.csproj` 文件，生成即可。或命令行：

```powershell
& "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\amd64\MSBuild.exe" .\一键修改账户名密码.csproj /restore /p:Configuration=Release
```

## 开发与协作规范

详细架构设计、WMI 调用机制与管理员权限约束请参阅 [AGENTS.md](./AGENTS.md)。

