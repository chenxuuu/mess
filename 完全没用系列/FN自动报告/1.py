import time
import os
while True:
    os.system('1.exe')
    time.sleep(5)
    os.system('taskkill /f /im 1.exe')
    time.sleep(10)
