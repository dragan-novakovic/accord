#!/bin/bash

# startup -s auth -db postgres

sIndex=0
dbIndex=0
serviceArgs=()
dbArgs=()

# validate services name
function validateServices() 
{
validServices=("auth")
for ser in $@
do
 for valid in ${validServices[@]}
 do 
  if [ $ser != $valid ]
  then
  echo Invalid service Name!
  exit 1
   else
    echo docker-compose run --rm $@
  fi
 done
done


}

#validate DBs name
function validateDBs()
{
validDbs=("mongo","postgres")
for ser in $@
do
 for valid in ${validDbs[@]}
 do 
  if [ $ser != $valid ]
  then
  echo Invalid db Name!
  exit 1
  fi
 done
done

echo docker-compose up $@ -d
}

if (( $# > 1 ))
then

 for (( i=1; i<=$#; i++ ))
 do
  if [ ${!i} == "-s" ]
  then
  sIndex=$i
  elif [ ${!i} == "-db" ]
  then
  dbIndex=$i
  fi
 done

#echo $sIndex
#echo $dbIndex

 if [ $sIndex -lt $dbIndex ]
 then 
  for (( j=1; j<=$#; j++ ))
  do
    if [ $j -gt $sIndex ] && [ $j -lt $dbIndex ]
    then
    serviceArgs=("${serviceArgs[@]}" "${!j}")
    elif [ $j -gt $dbIndex ] && (( $j <= $# ))
    then
    dbArgs=("${dbArgs[@]}" "${!j}")
    fi
  done
 fi


validateServices ${serviceArgs[@]}
validateDBs ${dbArgs[@]}
else
 echo Please provide input parameters!
fi



