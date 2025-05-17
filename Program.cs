using RtspClientSharp;
using RtspClientSharp.RawFrames.Audio;
using RtspClientSharp.RawFrames.Video;
using System;
using System.Net;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var creds = new NetworkCredential("admin", "somepassword");
            var cameraIp = "192.168.x.x";
            //Get list of URLs from nmap: nmap --script rtsp-url-brute -p 554 192.168.x.x
            List<string> urls = new()
            {
                $"rtsp://{cameraIp}/11",
                $"rtsp://{cameraIp}/1/stream1",
                $"rtsp://{cameraIp}/",
                $"rtsp://{cameraIp}/0",
                $"rtsp://{cameraIp}/0/video1",
                $"rtsp://{cameraIp}/1",
                $"rtsp://{cameraIp}/1.AMP",
                $"rtsp://{cameraIp}/1/1:1/main",
                $"rtsp://{cameraIp}/1/cif",
                $"rtsp://{cameraIp}/12",
                $"rtsp://{cameraIp}/CH001.sdp",
                $"rtsp://{cameraIp}/MJPEG.cgi",
                $"rtsp://{cameraIp}/GetData.cgi",
                $"rtsp://{cameraIp}/H264",
                $"rtsp://{cameraIp}/HighResolutionVideo",
                $"rtsp://{cameraIp}/HighResolutionvideo",
                $"rtsp://{cameraIp}/Image.jpg",
                $"rtsp://{cameraIp}/CAM_ID.password.mp2",
                $"rtsp://{cameraIp}/LowResolutionVideo",
                $"rtsp://{cameraIp}/4",
                $"rtsp://{cameraIp}/MediaInput/h264",
                $"rtsp://{cameraIp}/MediaInput/mpeg4",
                $"rtsp://{cameraIp}/ONVIF/MediaInput",
                $"rtsp://{cameraIp}/ONVIF/channel1",
                $"rtsp://{cameraIp}/PSIA/Streaming/channels/0?videoCodecType=H.264",
                $"rtsp://{cameraIp}/PSIA/Streaming/channels/1?videoCodecType=MPEG4",
                $"rtsp://{cameraIp}/PSIA/Streaming/channels/h264",
                $"rtsp://{cameraIp}/MediaInput/h264/stream_1",
                $"rtsp://{cameraIp}/PSIA/Streaming/channels/1",
                $"rtsp://{cameraIp}/Possible",
                $"rtsp://{cameraIp}/ROH/channel/11",
                $"rtsp://{cameraIp}/Streaming/Channels/1",
                $"rtsp://{cameraIp}/Streaming/Channels/101",
                $"rtsp://{cameraIp}/Streaming/Channels/103",
                $"rtsp://{cameraIp}/Streaming/Channels/2",
                $"rtsp://{cameraIp}/Streaming/Channels/102",
                $"rtsp://{cameraIp}/Video?Codec=MPEG4&Width=720&Height=576&Fps=30",
                $"rtsp://{cameraIp}/Streaming/Unicast/channels/101",
                $"rtsp://{cameraIp}/Streaming/channels/101",
                $"rtsp://{cameraIp}/VideoInput/1/h264/1",
                $"rtsp://{cameraIp}/access_code",
                $"rtsp://{cameraIp}/access_name_for_stream_1_to_5",
                $"rtsp://{cameraIp}/av0_0",
                $"rtsp://{cameraIp}/av0_1",
                $"rtsp://{cameraIp}/av2",
                $"rtsp://{cameraIp}/avn=2",
                $"rtsp://{cameraIp}/axis-media/media.amp?videocodec=h264&resolution=640x480",
                $"rtsp://{cameraIp}/cam",
                $"rtsp://{cameraIp}/axis-media/media.amp",
                $"rtsp://{cameraIp}/cam/realmonitor",
                $"rtsp://{cameraIp}/cam/realmonitor?channel=1&subtype=00",
                $"rtsp://{cameraIp}/cam/realmonitor?channel=1&subtype=01",
                $"rtsp://{cameraIp}/cam/realmonitor?channel=1&subtype=1",
                $"rtsp://{cameraIp}/cam0_0",
                $"rtsp://{cameraIp}/cam0_1",
                $"rtsp://{cameraIp}/cam1/h264",
                $"rtsp://{cameraIp}/cam1/h264/multicast",
                $"rtsp://{cameraIp}/cam1/onvif-h264",
                $"rtsp://{cameraIp}/cam1/mpeg4",
                $"rtsp://{cameraIp}/cam1/mjpeg",
                $"rtsp://{cameraIp}/ch0.h264",
                $"rtsp://{cameraIp}/cam4/mpeg4",
                $"rtsp://{cameraIp}/camera.stm",
                $"rtsp://{cameraIp}/cgi-bin/viewer/video.jpg?resolution=640x480",
                $"rtsp://{cameraIp}/ch0",
                $"rtsp://{cameraIp}/ch001.sdp",
                $"rtsp://{cameraIp}/ch01.264",
                $"rtsp://{cameraIp}/ch0_0.h264",
                $"rtsp://{cameraIp}/ch0_unicast_firststream",
                $"rtsp://{cameraIp}/ch0_unicast_secondstream",
                $"rtsp://{cameraIp}/dms.jpg",
                $"rtsp://{cameraIp}/dms?nowprofileid=2",
                $"rtsp://{cameraIp}/h264.sdp",
                $"rtsp://{cameraIp}/channel1",
                $"rtsp://{cameraIp}/h264",
                $"rtsp://{cameraIp}/h264/ch1/sub/",
                $"rtsp://{cameraIp}/h264/media.amp",
                $"rtsp://{cameraIp}/h264Preview_01_sub",
                $"rtsp://{cameraIp}/h264Preview_01_main",
                $"rtsp://{cameraIp}/h264_vga.sdp",
                $"rtsp://{cameraIp}/image.jpg",
                $"rtsp://{cameraIp}/image.mpg",
                $"rtsp://{cameraIp}/image/jpeg.cgi",
                $"rtsp://{cameraIp}/img/media.sav",
                $"rtsp://{cameraIp}/img/video.asf",
                $"rtsp://{cameraIp}/img/video.sav",
                $"rtsp://{cameraIp}/ioImage/1",
                $"rtsp://{cameraIp}/ipcam/stream.cgi?nowprofileid=2",
                $"rtsp://{cameraIp}/ipcam.sdp",
                $"rtsp://{cameraIp}/ipcam_h264.sdp",
                $"rtsp://{cameraIp}/jpg/image.jpg?size=3",
                $"rtsp://{cameraIp}/live",
                $"rtsp://{cameraIp}/live.sdp",
                $"rtsp://{cameraIp}/live/av0",
                $"rtsp://{cameraIp}/live/ch0",
                $"rtsp://{cameraIp}/live/ch00_0",
                $"rtsp://{cameraIp}/live/ch00_1",
                $"rtsp://{cameraIp}/live/h264",
                $"rtsp://{cameraIp}/live/ch2",
                $"rtsp://{cameraIp}/live/ch1",
                $"rtsp://{cameraIp}/live/mpeg4",
                $"rtsp://{cameraIp}/live0.264",
                $"rtsp://{cameraIp}/live1.264",
                $"rtsp://{cameraIp}/live1.sdp",
                $"rtsp://{cameraIp}/live2.sdp",
                $"rtsp://{cameraIp}/live3.sdp",
                $"rtsp://{cameraIp}/live_h264.sdp",
                $"rtsp://{cameraIp}/livestream",
                $"rtsp://{cameraIp}/live_mpeg4.sdp",
                $"rtsp://{cameraIp}/livestream/",
                $"rtsp://{cameraIp}/media",
                $"rtsp://{cameraIp}/media.amp",
                $"rtsp://{cameraIp}/media/media.amp",
                $"rtsp://{cameraIp}/media/video1",
                $"rtsp://{cameraIp}/media/video2",
                $"rtsp://{cameraIp}/media/video3",
                $"rtsp://{cameraIp}/medias1",
                $"rtsp://{cameraIp}/mjpeg.cgi",
                $"rtsp://{cameraIp}/mp4",
                $"rtsp://{cameraIp}/mjpeg/media.smp",
                $"rtsp://{cameraIp}/mpeg4",
                $"rtsp://{cameraIp}/mpeg4/1/media.amp",
                $"rtsp://{cameraIp}/mpeg4/media.amp",
                $"rtsp://{cameraIp}/mpeg4/media.amp?resolution=640x480",
                $"rtsp://{cameraIp}/mpeg4/media.smp",
                $"rtsp://{cameraIp}/mpeg4cif",
                $"rtsp://{cameraIp}/mpeg4unicast",
                $"rtsp://{cameraIp}/multicaststream",
                $"rtsp://{cameraIp}/mpg4/rtsp.amp",
                $"rtsp://{cameraIp}/now.mp4",
                $"rtsp://{cameraIp}/nph-h264.cgi",
                $"rtsp://{cameraIp}/nphMpeg4/g726-640x",
                $"rtsp://{cameraIp}/nphMpeg4/g726-640x480",
                $"rtsp://{cameraIp}/nphMpeg4/nil-320x240",
                $"rtsp://{cameraIp}/onvif-media/media.amp",
                $"rtsp://{cameraIp}/onvif/live/2",
                $"rtsp://{cameraIp}/onvif1",
                $"rtsp://{cameraIp}/onvif2",
                $"rtsp://{cameraIp}/play1.sdp",
                $"rtsp://{cameraIp}/play2.sdp",
                $"rtsp://{cameraIp}/rtsp_tunnel",
                $"rtsp://{cameraIp}/profile",
                $"rtsp://{cameraIp}/recognizer",
                $"rtsp://{cameraIp}/rtpvideo1.sdp",
                $"rtsp://{cameraIp}/rtsph264",
                $"rtsp://{cameraIp}/rtsph2641080p",
                $"rtsp://{cameraIp}/stream1",
                $"rtsp://{cameraIp}/stream2",
                $"rtsp://{cameraIp}/streaming/mjpeg",
                $"rtsp://{cameraIp}/synthesizer",
                $"rtsp://{cameraIp}/ucast/11",
                $"rtsp://{cameraIp}/unicast/c1/s1/live",
                $"rtsp://{cameraIp}/user.pin.mp2",
                $"rtsp://{cameraIp}/tcp/av0_0",
                $"rtsp://{cameraIp}/user_defined",
                $"rtsp://{cameraIp}/video",
                $"rtsp://{cameraIp}/video.3gp",
                $"rtsp://{cameraIp}/video.cgi?resolution=VGA",
                $"rtsp://{cameraIp}/video.cgi",
                $"rtsp://{cameraIp}/video.cgi?resolution=vga",
                $"rtsp://{cameraIp}/video.h264",
                $"rtsp://{cameraIp}/video.mp4",
                $"rtsp://{cameraIp}/video.mjpg",
                $"rtsp://{cameraIp}/video.pro2",
                $"rtsp://{cameraIp}/video.pro3",
                $"rtsp://{cameraIp}/video.pro1",
                $"rtsp://{cameraIp}/video/mjpg.cgi",
                $"rtsp://{cameraIp}/video2.mjpg",
                $"rtsp://{cameraIp}/video1",
                $"rtsp://{cameraIp}/video1+audio1",
                $"rtsp://{cameraIp}/videoMain",
                $"rtsp://{cameraIp}/videoinput_1:0/h264_1/onvif.stm",
                $"rtsp://{cameraIp}/videostream.cgi?rate=0",
                $"rtsp://{cameraIp}/vis",
                $"rtsp://{cameraIp}/wfov",
                $"rtsp://{cameraIp}/user=admin_password=tlJwpbo6_channel=1_stream=0.sdp?real_stream"
            };
            int i = 1;
            foreach(string url in urls)
            {
                Console.Write("\rTrying " + i + " out of " + urls.Count());
                i++;
                TryURLAndLog(url, creds);
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }

        public static void TryURLAndLog(string url, NetworkCredential creds)
        {
            var valid = AttemptToConnectToURL(url, creds);
            if (valid) {
                Console.WriteLine("\nValid URL found: " + url);
            }
        }

        public static bool AttemptToConnectToURL(string url, NetworkCredential credentials)
        {
            bool validUrl = false;
            var serverUri = new Uri(url);
            var connectionParameters = new ConnectionParameters(serverUri, credentials);
            connectionParameters.RtpTransport = RtpTransportProtocol.TCP;
            var cancellationTokenSource = new CancellationTokenSource();
            connectionParameters.ConnectTimeout = TimeSpan.FromSeconds(5);
            connectionParameters.CancelTimeout = TimeSpan.FromSeconds(5);
            using (var rtspClient = new RtspClient(connectionParameters))
            {
                rtspClient.FrameReceived += (sender, frame) =>
                {
                    //process (e.g. decode/save to file) encoded frame here or 
                    //make deep copy to use it later because frame buffer (see FrameSegment property) will be reused by client
                    switch (frame)
                    {
                        case RawH264IFrame h264IFrame:
                        case RawH264PFrame h264PFrame:
                        case RawJpegFrame jpegFrame:
                        case RawAACFrame aacFrame:
                        case RawG711AFrame g711AFrame:
                        case RawG711UFrame g711UFrame:
                        case RawPCMFrame pcmFrame:
                        case RawG726Frame g726Frame:
                            validUrl = true;
                            cancellationTokenSource.Cancel();
                            break;
                    }
                };

                try
                {
                    rtspClient.ConnectAsync(cancellationTokenSource.Token).Wait();
                    rtspClient.ReceiveAsync(cancellationTokenSource.Token).Wait();
                }
                catch (Exception) { }
            }
            return validUrl;
        }
    }
}