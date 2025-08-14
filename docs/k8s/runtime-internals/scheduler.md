````markdown
# Scheduler
Scheduler is a control plane component that watches for newly created pods with no assigned node, and selects a node for them to run on.

```sh
# Installation
curl -LO https://storage.googleapis.com/kubernetes-release/release/$(curl -s https://storage.googleapis.com/kubernetes-release/release/stable.txt)/bin/linux/amd64/kube-scheduler
```

```sh
# run as a service
cat <<EOF | sudo tee /etc/systemd/system/kube-scheduler.service
[Unit]
Description=Kubernetes Scheduler
Documentation=https://kubernetes.io/docs/concepts/scheduling-eviction/kube-scheduler/
After=network.target
[Service]
ExecStart=/usr/local/bin/kube-scheduler \\
    --config=/etc/kubernetes/kube-scheduler.yaml \\
    --v=2
```

```sh
# kube admin config
cat /etc/kubernetes/manifests/kube-scheduler.yaml
```

## Multiple Schedulers

You can run multiple schedulers in a cluster. Each scheduler can have its own configuration and scheduling policies.


```yaml
# my-scheduler2.yaml
apiVersion: kubescheduler.config.k8s.io/v1
kind: KubeSchedulerConfiguration
profiles:
- schedulerName: my-scheduler2
leaderElection:
  leaderElect: true
  resourceNamespace: kube-system
  resourceName: my-scheduler2
```

### Deploying as a Service
```sh
#my-scheduler2.service
[Unit]
Description=Kubernetes Scheduler 2
Documentation=https://kubernetes.io/docs/concepts/scheduling-eviction/kube-scheduler/
After=network.target
[Service]
ExecStart=/usr/local/bin/kube-scheduler \\
    --config=/etc/kubernetes/my-scheduler2.yaml
```

### Deploying a Pod with Custom Scheduler
```yaml
# pod-with-custom-scheduler.yaml
apiVersion: v1
kind: Pod
metadata:
  name: my-custom-scheduler-pod
  namespace: kube-system
spec:
  containers:
    - command:
      - kube-scheduler
      - --address=127.0.0.1
      - --kubeconfig=/etc/kubernetes/scheduler.conf
      - --config=/etc/kubernetes/my-scheduler2.yaml
    image: k8s.gcr.io/kube-scheduler:v1.27.0
    name: my-custom-scheduler

```

## Troubleshooting Scheduler
```sh
# Check scheduler logs
kubectl logs my-custom-scheduler --namespace=kube-system
````
