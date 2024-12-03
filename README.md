# IWebConsole

## 项目结构

```txt
Server
	|____ Controller
	|	|
	|_______|_______ Model
```

### 初始创建

| 项目   |  模板  | 说明 |
|-------|-------|-------|
| Server | ASP.NET Core Web API | 主启动程序 |
| Model  | Class Library        | 模型层 |
| View   | ASP.NET Core Web Application(MVC) | 视图层 |
| Controller | Class Library    | 控制器层 |

### 项目引用

```
Server -> Controller、View
View -> Model
Controller -> View、Model
```

注："->" 符号表示 引用
