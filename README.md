# ScreenCapturer
纯C#版屏幕截图,支持多屏幕,带遮罩层, 双击完成截图

## FScreen 截图参数

| 名称            | 类型  | 默认值 | 备注                   |
|:--------------|:------|:--------|:------------------|
| FixRect         | bool | true | 是否固定截图大小          |
| FixWidth        | int  | 200  | 固定截图大小时指定截图的宽 |
| FixHeight       | int  | 200  | 固定截图大小时指定截图的高 |
| SaveToClipboard | bool | true | 完成时是否保存截图到剪切板 |
| SaveToFolder    | bool | false | 完成时是否保存到目录      |
| Folder          | string | N/A | 保存的目录               |
| Transform       | bool | false | 是否需要在保存时调整截图大小 |
| TransformWidth  | int | 0 | 调整截图目标宽 |
| TransformHeight | int | 0 | 调整截图目标高 |
| LineColor       | Color | Red | 截图时的标线颜色 |
