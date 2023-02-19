#!/bin/sh

NAMESPACE=default

helm repo add postgres-operator-charts https://opensource.zalando.com/postgres-operator/charts/postgres-operator
helm repo add postgres-operator-ui-charts https://opensource.zalando.com/postgres-operator/charts/postgres-operator-ui

helm upgrade --install --namespace ${NAMESPACE} postgres-operator postgres-operator-charts/postgres-operator
helm upgrade --install --namespace ${NAMESPACE} postgres-operator-ui postgres-operator-ui-charts/postgres-operator-ui