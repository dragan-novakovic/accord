<script lang="ts">
	import { useForm, validators, HintGroup, Hint, email, required } from 'svelte-use-form';

	const form = useForm();

	const login = () => {
		console.log(form); // store(Observable) and Action
	};
</script>

<svelte:head>
	<title>Admin Portal | Login</title>
</svelte:head>

<section>
	<h1>Login</h1>
</section>
<form use:form>
	<input type="email" name="email" use:validators={[required, email]} />
	<HintGroup for="email">
		<Hint on="required">This is a mandatory field</Hint>
		<Hint on="email" hideWhenRequired>Email is not valid</Hint>
	</HintGroup>

	<input type="password" name="password" use:validators={[required]} />
	<Hint for="password" on="required">This is a mandatory field</Hint>

	<button disabled={!$form.valid} on:click={login}>Login</button>
</form>
<pre>
{JSON.stringify($form, null, ' ')}
</pre>

<style>
	:global(.touched:invalid) {
		border-color: red;
		outline-color: red;
	}

	section {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
		flex: 1;
	}

	h1 {
		width: 100%;
	}
</style>
