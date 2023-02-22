#!/bin/sh

SCRIPT=$(readlink -f "$0")
SCRIPT_PATH=$(dirname "$SCRIPT")

kubectl apply -f ${SCRIPT_PATH}/../manifests/mailslurper/mailslurper.yaml
kubectl apply -f ${SCRIPT_PATH}/../manifests/mailslurper/svc.yaml