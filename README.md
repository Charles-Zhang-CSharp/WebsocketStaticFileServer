# WebsocketStaticFileServer

This standalone AOT application provides static file serving capabilities with a simple protocol. All data transfer is binary.

Request: Requests are binary strings.

* `List [<Folder>]`: List available paths/files in folder.
* `Get <Path>`: Get file at path.

Response:

* `List` command returns plain strings separated by `\n`.
* `Get` command returns binary file content, starting with a 64bit file length.

## Reference

This implementation originally depends on https://github.com/sta/websocket-sharp but after re-discovering some issues (https://github.com/sta/websocket-sharp/issues/750 and https://github.com/sta/websocket-sharp/issues/745), we moved to a custom implementation.