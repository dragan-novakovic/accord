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
    command docker-compose run --rm $@
  fi
 done
done


}

#validate DBs name
function validateDBs()
{
validDbs=("mongo" "postgres")
for ser in $@
do
toBrake=0
 for valid in ${validDbs[@]}
 do 
  if [ $ser == $valid ]
  then
  toBrake=1
  fi
 done


if (( $toBrake == 0 ))
then
echo Invalid db Name! $ser
exit 1
fi
done

command docker-compose up $@ -d
}

function addToServicePipeline()
{
 for (( j=$sIndex+1; j<=$#; j++ ))
  do
    serviceArgs=("${serviceArgs[@]}" "${!j}")
  done
}

function addToDBPipeline()
{
 for (( j=$dbIndex+1; j<=$#; j++ ))
  do
    dbArgs=("${dbArgs[@]}" "${!j}")
  done
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
if [ $sIndex -gt 0 ] && [ $dbIndex -gt 0 ]
then
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
elif [ $sIndex -gt 0 ]
then 
addToServicePipeline $@
validateServices ${serviceArgs[@]}
elif [ $dbIndex -gt 0 ]
then 
addToDBPipeline $@
validateDBs ${dbArgs[@]}
fi
else
 echo Please provide input parameters!
fi



