#!/bin/sh

SCRIPT=$(readlink -f "$0")
SCRIPT_PATH=$(dirname "$SCRIPT")

helm repo add ory https://k8s.ory.sh/helm/charts
helm repo update

helm upgrade --install -f ${SCRIPT_PATH}/../manifests/kratos/values.yaml ory/kratos