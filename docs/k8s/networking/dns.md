
services (Kind: service api: v1) - resolvable within the cluster by their name.
For example, a service named `my-service` in the `default` namespace is accessible at `my-service` or `my-service.default` or `my-service.default.svc` or `my-service.default.svc.cluster.local`.

for pods - by default, k8s does not create DNS records for pods. You can change that behavior then pods will be accessible by their IP address and a DNS record will be created in the form: `<pod-ip-address>.<namespace>.pod.cluster.local`.