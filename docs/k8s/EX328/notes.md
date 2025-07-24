# OpenShift Service Mash Concepts

## Challenges

**Development challenges**:
 -  *Discovery* - services are often changing their IPs, each service needs to be referred to by a static name. 
 - *Elasticity* - a system is scalable and have a orchestration solution.

**Security challenges** - Security is a critical aspect of application development and deployment. In microservice architectures, services authenticate requests to validate identities. Microservices must authorize these validated requests and reject any that are unauthorized.

**Operational challenges**: 
 - *Monitoring*: measuring microservices performance and usage.

 - *Centralized logging*: capturing and relating logs from all microservices.

 - *Tracing*: correlating requests to multiple microservices belonging to the same user transaction.

 ## Components

 **istio** - istio is the core implementation of the service mesh architecture for the Kubernetes platform. Istio creates a control plane that centralizes service mesh capabilities and a data plane that creates the structure of the mesh. The data plane controls communication between services by injecting sidecar containers that capture traffic between services.

 **Maistra** - *Maistra* adds extended features to *Istio*, such as simplified multitenancy, explicit sidecar injection, and the use of OpenShift routes instead of Kubernetes ingress.

**Jaeger** - an open-source server that centralizes and displays request traces. Each trace details all services a request interacts with. Maistra sends these traces to Jaeger for display, while microservices generate the necessary request headers for trace creation and aggregation.

**ElasticSearch**

**Kiali** - an open-source observability console for Istio that helps visualize the service mesh topology, monitor the health of services, and troubleshoot issues.

**Prometheus** - an open-source server that collects and stores metrics from services in the mesh. Prometheus scrapes metrics from services and stores them in a time-series database. It also provides a query language to retrieve and display metrics.

**Grafana**

**3scale**


# Red Hat OpenShift Service Mesh Architecture

## Data Plane

* A set of Envoy proxies

* istio-agent (aka istio Pilot) - running in each Envoy proxy

## The data plane performs the following tasks:
   
 *   **Service discovery**: Tracks the services deployed in a mesh.
 *   **Health checks**: Track the state (healthy or unhealthy) of the services deployed in a mesh.
 *   **Traffic shaping and routing**: Control the flow of network data between services. This includes tasks such as:
     *   Throttling the amount of traffic.
     *   Routing based on content.
     *   Circuit breaking.
     *   Controlling the amount of traffic routed among multiple versions of a service.
     *   Load balancing.
 *   **Security**: Perform authentication and authorization, and secure communication using mutual transport layer security (mTLS) between services in a mesh.
 *   **Metrics and Telemetry**: Gather metrics, logs, and distributed tracing information from services in the mesh.


## Control Plane

The control plane manages the configuration and policies for the service mesh.

The control plane consists of the **istiod** deployment. The **istiod** deployment consists of a single binary that contains a number of APIs used by the OpenShift Service Mesh.

Istiod contains the APIs and functionality of the following components:

* **Pilot** - Provides service discovery, traffic management, and routing capabilities.
* **Citadel** - Provides security capabilities, such as certificate management and identity.
* **Galley** - Provides configuration validation, ingestion, and distribution. 