# Lucas-Lehmer

A C# console app for running the [Lucas-Lehmer primality test](https://en.wikipedia.org/wiki/Lucas%E2%80%93Lehmer_primality_test).

Given a [prime number](https://en.wikipedia.org/wiki/Prime_number) (from which is derived a [Mersenne number](https://en.wikipedia.org/wiki/Mersenne_prime)) this test is able to definitively assert primality or compositeness of the Mersenne number.

This works for extraordinarily large numbers e.g. with > 20M digits as demonstrated by the [Great Internet Mersenne Prime Search](https://en.wikipedia.org/wiki/Great_Internet_Mersenne_Prime_Search), which has developed a sophisticated approach to the algorithm optimised for speed.

The app here is not optimised, it is purely for running against smaller Mersenne Primes to see the intermediate loop values.


## Timings

On my [Schenker XMG C703](https://www.notebookcheck.net/Schenker-XMG-C703.107370.0.html) with an Intel Core i7-4700HQ, I observed the following times:

| Candidate prime | Mersenne prime (Mp) | Time taken |
| ---------------: | --------------: | ------: |
| 1279  | 1040...9087 (386 digits) | 0.025s |
| 9689 | 4782...4111 (2917 digits) | 8.5s |
| 21701 | 4486...2751 (6533 digits) | 1m 33s |
| 86243 | 5369...8207 (25962 digits) | 1h 37m 58s |

Notes:
* There is little difference whether the Mersenne number is found to be prime or not as the algorithm runs to completion in both cases.
* RAM is essentially irrelevant. My VS2017 in debug shows the app using about 14M. The [Garbage Collector](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/) runs every few seconds as many [BigIntegers](https://msdn.microsoft.com/en-us/library/system.numerics.biginteger(v=vs.110).aspx) are created and disposed; this might be a good area to look for optimisations.
* For these tests, I ran the app with only the -t and -p options. Adding -l and particularly -x and -d slows things down considerably with larger numbers as there is a lot of console output.


## Command line parameters
  `-p, --prime`        // **Required**. Candidate prime to be processed. e.g. `-p 127`

  `-t, --showTimes`    // Show total time taken.

  `-l, --showLoopCount`     // Show each loop count.

  `-x, --showSiInHex`       //Show Si in hex after each loop.

  `-d, --showSiInDec`       //Show Si in decimal after each loop.

  `-g, --showDigitCount`    //Show Mp digit count if Mp found.

## Credits
Command Line Parser Library at http://commandline.codeplex.com/