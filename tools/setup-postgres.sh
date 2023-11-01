#!/bin/sh

SCRIPT=$(readlink -f "$0")
SCRIPTPATH=$(dirname "$SCRIPT")

. ${SCRIPTPATH}/setup-postgres-operator.sh

kubectl apply -f ${SCRIPTPATH}/../manifests/postgres/postgres-cluster.yaml
kubectl apply -f ${SCRIPTPATH}/../manifests/postgres/svc.yaml
kubectl apply -f ${SCRIPTPATH}/../manifests/postgres/pgadmin.yaml
