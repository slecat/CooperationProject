项目文件夹规范：
    -项目
        -Scripts
            -场景
                -场景名.cs(场景主脚本,可以为场景名)
                -Command
                    -xxxxCommand.cs
                -Event
                    -xxxxEvent.cs
                -System
                    -xxxxSystem.cs
                -Model
                    --xxxxModel.cs
                -ViewControllers(用于放ViewController自定生成的脚本)
                    --xxxx.cs
                --Resources
                --Animations
        -Scens
        -....

变量命名建议:
UI.Button Btnxxx
UI.Toggle Togxxx
UI.Image Imgxxx
变量名用第一个字母以小写开头
例:
    Password x
    password √
    NetCheck ×
    netCheck √
或者:
    mNetCheck
    mPassword

git常用命令
#跟踪当前目录下所有文件
git add .
#提交所有跟踪文件
git commit -m "first Commit"
#将本地分支上传到远程
git push origin
#指定push对应分支
git push origin <local_branch>:<remote_branch>
#强制push覆盖远程
git push origin -f
#拉取远程分支到本地并合并
git pull origin
#指定pull对应分支
git pull origin <local_branch>:<remote_branch>
#强制pull覆盖本地
git pull --force
强制pull覆盖本地
    #拉取远程分支到本地但不进行合并
    git fetch origin
    #回退本地分支到远程分支的状态
    git reset --hard origin
    git pull

#创建分支
git branch <new_branch>
#切换分支
git switch <branch>
#查看所有分支
git branch -a 


#设置代理
git config --global --add proxy.http <proxy_ipaddress>:<proxy_port>
#查看代理
git config --global proxy.http
#取消代理
git config --global --unset proxy.http

#查看所有已跟踪文件
git ls-files
#不再跟踪<FileName>文件
git rm --cached FileName
#不再跟踪<Filedir>文件夹下所有文件
git rm -r --cached FileName
