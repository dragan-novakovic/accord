FROM denoland/deno:1.38.0

# The port that your application listens to.
EXPOSE 1993

WORKDIR /app

# Prefer not to run as root.

# Install denon
RUN deno install -A --allow-read --allow-run --allow-write --allow-env -f --unstable https://deno.land/x/denon/denon.ts

# Cache the dependencies as a layer (the following two steps are re-run only when deps.ts is modified).
# Ideally cache deps.ts will download and compile _all_ external files used in main.ts.

# These steps will be re-run upon each file change in your working directory:
COPY . .
# Compile the main app so that it doesn't need to be compiled each startup/entry.
RUN deno cache server.ts

CMD ["denon", "run", "--allow-net", "server.ts"]