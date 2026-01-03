# DNS Issues Troubleshooting

[link](https://kubernetes.io/docs/tasks/administer-cluster/dns-debugging-resolution/)

Memory and Pods

In large scale Kubernetes clusters, CoreDNS's memory usage is predominantly affected by the number of Pods and Services in the cluster. 

Other factors include the size of the filled DNS answer cache, and the rate of queries received (QPS) per CoreDNS instance.


Kubernetes resources for coreDNS are: 

- a service account named coredns,
- cluster-roles named coredns and kube-dns
- clusterrolebindings named coredns and kube-dns, 
- a deployment named coredns,
- a configmap named coredns and a
- service named kube-dns.


**Corefile plugin** consists of important configuration which is defined as a ConfigMap.

```
Corefile: |
    .:53 {
        errors {
        }
        health {
            lameduck 5s
        }
        ready
        kubernetes malinka-cl.lan in-addr.arpa ip6.arpa {
          pods insecure
          fallthrough in-addr.arpa ip6.arpa
        }
        prometheus :9153
        forward . /etc/resolv.conf {
          prefer_udp
          max_concurrent 1000
        }
        cache 30

        loop
        reload
        loadbalance
    }
```


## Troubleshooting issues related to coreDNS

1. If you find CoreDNS pods in pending state first check network plugin is installed.

2. coredns pods have CrashLoopBackOff or Error state

If you have nodes that are running SELinux with an older version of Docker you might experience a scenario where the coredns pods are not starting. To solve that you can try one of the following options:

a. Upgrade to a newer version of Docker.

b. Disable SELinux.

c. Modify the coredns deployment to set allowPrivilegeEscalation to true:

```sh
kubectl -n kube-system get deployment coredns -o yaml | \
  sed 's/allowPrivilegeEscalation: false/allowPrivilegeEscalation: true/g' | \
  kubectl apply -f -
```
d. Another cause for CoreDNS to have CrashLoopBackOff is when a CoreDNS Pod deployed in Kubernetes detects a loop.


There are many ways to work around this issue, some are listed here:


Add the following to your kubelet config yaml: resolvConf: <path-to-your-real-resolv-conf-file> This flag tells kubelet to pass an alternate resolv.conf to Pods. For systems using systemd-resolved, /run/systemd/resolve/resolv.conf is typically the location of the "real" resolv.conf, although this can be different depending on your distribution.

Disable the local DNS cache on host nodes, and restore /etc/resolv.conf to the original.

A quick fix is to edit your Corefile, replacing forward . /etc/resolv.conf with the IP address of your upstream DNS, for example forward . 8.8.8.8. But this only fixes the issue for CoreDNS, kubelet will continue to forward the invalid resolv.conf to all default dnsPolicy Pods, leaving them unable to resolve DNS.


3. If CoreDNS pods and the kube-dns service is working fine, check the kube-dns service has valid endpoints.

              kubectl -n kube-system get ep kube-dns

If there are no endpoints for the service, inspect the service and make sure it uses the correct selectors and ports.


