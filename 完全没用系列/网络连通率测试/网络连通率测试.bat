@echo off
:loop
cls
echo ********************************
echo *     延迟测试脚本   by晨旭    *
echo ********************************
echo 测试失败，重新开始测试
ping baidu.com -n 1&&echo 成功1次||echo 测试失败&&goto:loop
ping -n 5 127.1>nul
ping baidu.com -n 1&&echo 成功2次||echo 测试失败&&goto:loop
ping -n 5 127.1>nul
ping baidu.com -n 1&&echo 成功3次||echo 测试失败&&goto:loop
ping -n 5 127.1>nul
ping baidu.com -n 1&&echo 成功4次||echo 测试失败&&goto:loop
ping -n 5 127.1>nul
ping baidu.com -n 1&&echo 成功5次||echo 测试失败&&goto:loop
ping -n 5 127.1>nul
ping baidu.com -n 1&&echo 成功6次||echo 测试失败&&goto:loop
ping -n 5 127.1>nul
ping baidu.com -n 1&&echo 成功7次||echo 测试失败&&goto:loop
ping -n 5 127.1>nul
ping baidu.com -n 1&&echo 成功8次||echo 测试失败&&goto:loop
ping -n 5 127.1>nul
ping baidu.com -n 1&&echo 成功9次||echo 测试失败&&goto:loop
ping -n 5 127.1>nul
ping baidu.com -n 1&&echo 成功10次||echo 测试失败&&goto:loop
cls
echo 网络通畅！
pause