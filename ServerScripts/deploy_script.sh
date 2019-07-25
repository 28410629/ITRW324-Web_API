#!/bin/bash

# this script should be located within the main directroy of the git repo

# --execute command below to store credentials for git on server : 
# git config --global credential.helper 'store --file ~/.my-credentials'

# --add the following to "sudo crontab -e", take note dir should be set to a directory that the script is located in.
# * * * * * dir/pull_script.sh
DATE=$(date)
ACTION='\033[1;90m'
FINISHED='\033[1;96m'
READY='\033[1;92m'
NOCOLOR='\033[0m' # No Color
ERROR='\033[0;31m'

echo $DATE >> ./deploy_log.txt
echo "Checking Git repo" >> ./deploy_log.txt
echo ======================= >> ./deploy_log.txt
BRANCH=$(git rev-parse --abbrev-ref HEAD)
if [ "$BRANCH" != "master" ]
  then
    echo "Not on master. Aborting." >> ./deploy_log.txt
    echo
    exit 0
    else
      git fetch
      HEADHASH=$(git rev-parse HEAD)
      UPSTREAMHASH=$(git rev-parse master@{upstream})
      if [ "$HEADHASH" != "$UPSTREAMHASH" ]
        then
          # add code here to set what happens when not up to date
          echo "Not up to date with origin. Pulling." >> ./deploy_log.txt
          # stop service

          # pull changes
          git pull >> ./deploy_log.txt 2>&1
          # start service
          
          echo
          exit 0
        else
          echo "Current branch is up to date with origin/master." >> ./deploy_log.txt
      fi
fi