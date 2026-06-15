helm -n kong install -f cp-values.yaml kong kong/kong --version 2.52.0

kubectl -n kong rollout status deployment kong-kong --timeout=300s

http --headers GET $KONG_ADMIN_API_URL

helm -n kong-dp install -f dp-values.yaml kong kong/kong

# mesh

helm repo add kong-mesh https://kong.github.io/kong-mesh-charts

helm -n kong-mesh-system install kong-mesh kong-mesh/kong-mesh \
  --version "$KONG_MESH_VERSION" -f values.K8sZone.yaml

kubectl -n kong-mesh-system wait --for=condition=ready pod -l app=kong-mesh-control-plane --timeout=300s

| PORT | USAGE                                                   |
|------|---------------------------------------------------------|
| 443  | KUMA_RUNTIME_KUBERNETES_ADMISSION_SERVER_PORT           |
| 5680 | KUMA_DIAGNOSTICS_SERVER_PORT                            |
| 5681 | KUMA_API_SERVER_HTTP_PORT                               |
| 5682 | KUMA_API_SERVER_HTTPS_PORT                              |
| 5676 | KUMA_MONITORING_ASSIGNMENT_SERVER_PORT                  |
| 5678 | KUMA_RUNTIME_KUBERNETES_INJECTOR_SIDECAR_CONTAINER_UID  |