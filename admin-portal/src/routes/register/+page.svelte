<script lang="ts">
	import { useForm, validators, HintGroup, Hint, email, required } from 'svelte-use-form';

	const form = useForm();

	const Register = async () => {
		const {username, password} = $form.values;

		console.log(email, password);
		
		const response = await fetch('http://localhost:1993/auth/register', {
			method: 'POST',
			body: JSON.stringify({ username , password })
		});
		
const data = await response.json();
		console.log({ data });
	};
</script>

<svelte:head>
	<title>Admin Portal | Register</title>
</svelte:head>

<section>
	<h1>Register</h1>
</section>
<form use:form>
	<input type="username" name="username" />
	<HintGroup for="username">
		<Hint on="required">This is a mandatory field</Hint>
		<Hint on="username" hideWhenRequired>Email is not valid</Hint>
	</HintGroup>

	<input type="password" name="password" />
	<Hint for="password" on="required">This is a mandatory field</Hint>
	<button on:click={Register}>Register</button>
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
