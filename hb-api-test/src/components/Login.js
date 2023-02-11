import React from "react";

const Login = async () => {
  //   const res = await fetch(
  //     "https://sandbox.handelsbanken.com/openbanking/oauth2/token/1.0",
  //     {
  //       method: "POST",
  //       headers: {
  //         Accept: "application/json",
  //         "Content-Type": "application/json",
  //       },
  //       body: JSON.stringify({
  //         grant_type: "client_credentials",
  //         scope: "AIS",
  //         client_id: process.env.NEXT_PUBLIC_CLIENT_ID,
  //       }),
  //     }
  //   );

  //   console.log(res);

  //   const data = await res.json();

  //   console.log(data);

  //   const res2 = await fetch(
  //     "https://sandbox.handelsbanken.com/openbanking/psd2/v1/consents",
  //     {
  //       method: "POST",
  //       headers: {
  //         "X-IBM-Client-Id": process.env.NEXT_PUBLIC_CLIENT_ID,
  //         Authorization: `${data.token_type} ${data.access_token}`,
  //         Accept: "application/json",
  //         "Content-Type": "application/json",
  //         "TPP-Request-ID": "c8271b81-4229-5a1f-bf9c-758f11c1f5b1",
  //         "TPP-Transaction-ID": "6b24ce42-237f-4303-a917-cf778e5013d6",
  //         "Country": "SE",
  //       },
  //       body: JSON.stringify({
  //         access: "ALL_ACCOUNTS",
  //       })
  //     }
  //   );

  //   console.log(res2);

  //   const data2 = await res2.json();

  //   console.log(data2);

  const res3 = await fetch(
    "https://sandbox.handelsbanken.com/openbanking/psd2/v2/accounts",
    {
      method: "GET",
      headers: {
        "X-IBM-Client-Id": process.env.NEXT_PUBLIC_CLIENT_ID,
        Authorization: `Bearer MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI1`, // Test auth
        Accept: "application/json",
        "Content-Type": "application/json",
        "TPP-Request-ID": "c8271b81-4229-5a1f-bf9c-758f11c1f5b1",
        "TPP-Transaction-ID": "6b24ce42-237f-4303-a917-cf778e5013d6",
      },
    }
  );

  const data3 = await res3.json();

  console.log(data3);

  //   const res4 = await fetch(
  //     "https://sandbox.handelsbanken.com/openbanking/psd2/v2/accounts/ae57e780-6cf3-11e9-9c41-e957ce7d7d69",
  //     {
  //       method: "GET",
  //       headers: {
  //         "X-IBM-Client-Id": process.env.NEXT_PUBLIC_CLIENT_ID,
  //         Authorization: `Bearer MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI1`, // Test auth
  //         Accept: "application/json",
  //         "Content-Type": "application/json",
  //         "TPP-Request-ID": "c8271b81-4229-5a1f-bf9c-758f11c1f5b1",
  //         "TPP-Transaction-ID": "6b24ce42-237f-4303-a917-cf778e5013d6",
  //       },
  //     }
  //   );

  //   const data4 = await res4.json();

  //   console.log(data4);

  const res5 = await fetch(
    "https://sandbox.handelsbanken.com/openbanking/psd2/v2/accounts/ae57e780-6cf3-11e9-9c41-e957ce7d7d69/transactions",
    {
      method: "GET",
      headers: {
        "X-IBM-Client-Id": process.env.NEXT_PUBLIC_CLIENT_ID,
        Authorization: `Bearer MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI1`, // Test auth
        Accept: "application/json",
        "Content-Type": "application/json",
        "TPP-Request-ID": "c8271b81-4229-5a1f-bf9c-758f11c1f5b1",
        "TPP-Transaction-ID": "6b24ce42-237f-4303-a917-cf778e5013d6",
      },
    }
  );

  const data5 = await res5.json();

  console.log(data5);
  console.log(data5.transactions[3]);

  const res6 = await fetch(
    "https://sandbox.handelsbanken.com/openbanking/psd2/v1/card-accounts",
    {
      method: "GET",
      headers: {
        "X-IBM-Client-Id": process.env.NEXT_PUBLIC_CLIENT_ID,
        Authorization: `Bearer QVQ6NmQ4OTQwYWUtZjRmZi00NGMwLWJkYWQtZWU3ZTM0MTgxOTdmCg==`, // Test auth
        Accept: "application/json",
        "Content-Type": "application/json",
        "TPP-Request-ID": "c8271b81-4229-5a1f-bf9c-758f11c1f5b1",
        "TPP-Transaction-ID": "6b24ce42-237f-4303-a917-cf778e5013d6",
      },
    }
  );

  const data6 = await res6.json();

  console.log(data6);

  const res7 = await fetch(
    "https://sandbox.handelsbanken.com/openbanking/psd2/v1/card-accounts/4616a06a-337e-11ea-aec2-2e728ce88125/transactions",
    {
      method: "GET",
      headers: {
        "X-IBM-Client-Id": process.env.NEXT_PUBLIC_CLIENT_ID,
        Authorization: `Bearer QVQ6NmQ4OTQwYWUtZjRmZi00NGMwLWJkYWQtZWU3ZTM0MTgxOTdmCg==`, // Test auth
        Accept: "application/json",
        "Content-Type": "application/json",
        "TPP-Request-ID": "c8271b81-4229-5a1f-bf9c-758f11c1f5b1",
        "TPP-Transaction-ID": "6b24ce42-237f-4303-a917-cf778e5013d6",
      },
    }
  );

  const data7 = await res7.json();

  console.log(data7);

  return (
    <div>
      Login
      {/* <p>{JSON.stringify(data)}</p> */}
    </div>
  );
};

export default Login;
