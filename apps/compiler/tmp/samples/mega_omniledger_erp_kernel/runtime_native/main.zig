const std = @import("std");
const builtin = @import("builtin");
var spiral_arena = std.heap.ArenaAllocator.init(std.heap.page_allocator);
extern "kernel32" fn GetStdHandle(id: u32) callconv(.winapi) ?*anyopaque;
extern "kernel32" fn WriteFile(handle: ?*anyopaque, buffer: [*]const u8, length: u32, written: ?*u32, overlapped: ?*anyopaque) callconv(.winapi) i32;
fn spiralWrite(stream: u2, bytes: []const u8) void {
    if (builtin.os.tag == .windows) {
        const handle = GetStdHandle(if (stream == 1) 0xFFFFFFF5 else 0xFFFFFFF4);
        var rest = bytes;
        while (rest.len > 0) {
            var written: u32 = 0;
            const chunk: u32 = @intCast(@min(rest.len, 1 << 30));
            if (WriteFile(handle, rest.ptr, chunk, &written, null) == 0) return;
            rest = rest[written..];
        }
    } else if (builtin.os.tag == .linux) {
        var rest = bytes;
        while (rest.len > 0) {
            const n = std.os.linux.write(stream, rest.ptr, rest.len);
            if (@as(isize, @bitCast(n)) <= 0) return;
            rest = rest[n..];
        }
    } else {
        _ = std.c.write(stream, bytes.ptr, bytes.len);
    }
}
pub const panic = std.debug.FullPanic(spiralPanic);
fn spiralPanic(message: []const u8, _: ?usize) noreturn {
    spiralFlush();
    spiralWrite(2, message);
    spiralWrite(2, "\n");
    std.process.exit(3);
}
var spiral_gpa: std.mem.Allocator = undefined;
var spiral_environ: std.process.Environ = .empty;
var spiral_true: bool = true;
var spiral_out_buffer: [1 << 16]u8 = undefined;
var spiral_out_len: usize = 0;
fn spiralFlush() void {
    if (spiral_out_len == 0) return;
    spiralWrite(1, spiral_out_buffer[0..spiral_out_len]);
    spiral_out_len = 0;
}
fn spiralFail(s: []const u8) noreturn {
    spiralFlush();
    spiralWrite(2, s);
    spiralWrite(2, "\n");
    std.process.exit(1);
}
const US0 = struct { tag: i32, c0_0: i64 = undefined, c0_1: i64 = undefined, c0_2: i64 = undefined, c0_3: i64 = undefined, c0_4: i64 = undefined, c0_5: []const u8 = undefined, c1_0: i64 = undefined, c1_1: i64 = undefined, c1_2: []const u8 = undefined };
fn US0_TypedFxHashedStatementChecksumValidationAccepted(a0: i64, a1: i64, a2: i64, a3: i64, a4: i64, a5: []const u8) US0 {
    return US0{ .tag = 0, .c0_0 = a0, .c0_1 = a1, .c0_2 = a2, .c0_3 = a3, .c0_4 = a4, .c0_5 = a5 };
}
fn US0_TypedFxHashedStatementChecksumValidationRejected(a0: i64, a1: i64, a2: []const u8) US0 {
    return US0{ .tag = 1, .c1_0 = a0, .c1_1 = a1, .c1_2 = a2 };
}
fn spiralMain() i32 {
    var v58: i64 = undefined; _ = &v58;
    var v62: i64 = undefined; _ = &v62;
    var v74: i64 = undefined; _ = &v74;
    var v95: i64 = undefined; _ = &v95;
    var v99: i64 = undefined; _ = &v99;
    var v111: i64 = undefined; _ = &v111;
    var v127: i64 = undefined; _ = &v127;
    var v131: i64 = undefined; _ = &v131;
    var v143: i64 = undefined; _ = &v143;
    var v161: i64 = undefined; _ = &v161;
    var v165: i64 = undefined; _ = &v165;
    var v177: i64 = undefined; _ = &v177;
    var v193: i64 = undefined; _ = &v193;
    var v197: i64 = undefined; _ = &v197;
    var v209: i64 = undefined; _ = &v209;
    var v226: i64 = undefined; _ = &v226;
    var v230: i64 = undefined; _ = &v230;
    var v242: i64 = undefined; _ = &v242;
    var v260: i64 = undefined; _ = &v260;
    var v264: i64 = undefined; _ = &v264;
    var v276: i64 = undefined; _ = &v276;
    var v292: i64 = undefined; _ = &v292;
    var v296: i64 = undefined; _ = &v296;
    var v308: i64 = undefined; _ = &v308;
    var v325: i64 = undefined; _ = &v325;
    var v329: i64 = undefined; _ = &v329;
    var v341: i64 = undefined; _ = &v341;
    var v357: i64 = undefined; _ = &v357;
    var v361: i64 = undefined; _ = &v361;
    var v373: i64 = undefined; _ = &v373;
    var v392: i64 = undefined; _ = &v392;
    var v396: i64 = undefined; _ = &v396;
    var v408: i64 = undefined; _ = &v408;
    var v424: i64 = undefined; _ = &v424;
    var v428: i64 = undefined; _ = &v428;
    var v440: i64 = undefined; _ = &v440;
    var v457: i64 = undefined; _ = &v457;
    var v461: i64 = undefined; _ = &v461;
    var v473: i64 = undefined; _ = &v473;
    var v489: i64 = undefined; _ = &v489;
    var v493: i64 = undefined; _ = &v493;
    var v505: i64 = undefined; _ = &v505;
    var v523: i64 = undefined; _ = &v523;
    var v527: i64 = undefined; _ = &v527;
    var v539: i64 = undefined; _ = &v539;
    var v558: i64 = undefined; _ = &v558;
    var v562: i64 = undefined; _ = &v562;
    var v574: i64 = undefined; _ = &v574;
    var v621: US0 = undefined; _ = &v621;
    var v585: i64 = undefined; _ = &v585;
    var v586: i64 = undefined; _ = &v586;
    var v587: i64 = undefined; _ = &v587;
    var v588: i64 = undefined; _ = &v588;
    var v589: i64 = undefined; _ = &v589;
    var v590: i64 = undefined; _ = &v590;
    var v591: i64 = undefined; _ = &v591;
    var v592: i64 = undefined; _ = &v592;
    var v593: bool = undefined; _ = &v593;
    var v594: i64 = undefined; _ = &v594;
    var v595: i64 = undefined; _ = &v595;
    var v596: i64 = undefined; _ = &v596;
    var v597: bool = undefined; _ = &v597;
    var v598: i64 = undefined; _ = &v598;
    var v599: i64 = undefined; _ = &v599;
    var v600: i64 = undefined; _ = &v600;
    var v601: i64 = undefined; _ = &v601;
    var v602: i64 = undefined; _ = &v602;
    var v603: i64 = undefined; _ = &v603;
    var v604: i64 = undefined; _ = &v604;
    var v605: i64 = undefined; _ = &v605;
    var v606: i64 = undefined; _ = &v606;
    var v607: i64 = undefined; _ = &v607;
    var v608: i64 = undefined; _ = &v608;
    var v609: bool = undefined; _ = &v609;
    var v610: i64 = undefined; _ = &v610;
    var v611: i64 = undefined; _ = &v611;
    var v612: i64 = undefined; _ = &v612;
    var v613: i64 = undefined; _ = &v613;
    var v614: i64 = undefined; _ = &v614;
    var v615: i64 = undefined; _ = &v615;
    var v616: i64 = undefined; _ = &v616;
    var v617: []const u8 = undefined; _ = &v617;
    var v619: []const u8 = undefined; _ = &v619;
    var v640: i64 = undefined; _ = &v640;
    var v641: i64 = undefined; _ = &v641;
    var v644: i64 = undefined; _ = &v644;
    var v645: i64 = undefined; _ = &v645;
    var v646: i64 = undefined; _ = &v646;
    var v647: i64 = undefined; _ = &v647;
    var v648: i64 = undefined; _ = &v648;
    var v625: i64 = undefined; _ = &v625;
    var v626: i64 = undefined; _ = &v626;
    var v627: i64 = undefined; _ = &v627;
    var v628: i64 = undefined; _ = &v628;
    var v629: i64 = undefined; _ = &v629;
    var v630: []const u8 = undefined; _ = &v630;
    var v622: i64 = undefined; _ = &v622;
    var v623: i64 = undefined; _ = &v623;
    var v624: []const u8 = undefined; _ = &v624;
    var v675: i64 = undefined; _ = &v675;
    var v679: i64 = undefined; _ = &v679;
    var v691: i64 = undefined; _ = &v691;
    var v707: i64 = undefined; _ = &v707;
    var v711: i64 = undefined; _ = &v711;
    var v723: i64 = undefined; _ = &v723;
    var v740: i64 = undefined; _ = &v740;
    var v744: i64 = undefined; _ = &v744;
    var v756: i64 = undefined; _ = &v756;
    var v772: i64 = undefined; _ = &v772;
    var v776: i64 = undefined; _ = &v776;
    var v788: i64 = undefined; _ = &v788;
    var v806: i64 = undefined; _ = &v806;
    var v810: i64 = undefined; _ = &v810;
    var v822: i64 = undefined; _ = &v822;
    var v841: i64 = undefined; _ = &v841;
    var v845: i64 = undefined; _ = &v845;
    var v857: i64 = undefined; _ = &v857;
    var v904: US0 = undefined; _ = &v904;
    var v868: i64 = undefined; _ = &v868;
    var v869: i64 = undefined; _ = &v869;
    var v870: i64 = undefined; _ = &v870;
    var v871: i64 = undefined; _ = &v871;
    var v872: i64 = undefined; _ = &v872;
    var v873: i64 = undefined; _ = &v873;
    var v874: i64 = undefined; _ = &v874;
    var v875: i64 = undefined; _ = &v875;
    var v876: bool = undefined; _ = &v876;
    var v877: i64 = undefined; _ = &v877;
    var v878: i64 = undefined; _ = &v878;
    var v879: i64 = undefined; _ = &v879;
    var v880: bool = undefined; _ = &v880;
    var v881: i64 = undefined; _ = &v881;
    var v882: i64 = undefined; _ = &v882;
    var v883: i64 = undefined; _ = &v883;
    var v884: i64 = undefined; _ = &v884;
    var v885: i64 = undefined; _ = &v885;
    var v886: i64 = undefined; _ = &v886;
    var v887: i64 = undefined; _ = &v887;
    var v888: i64 = undefined; _ = &v888;
    var v889: i64 = undefined; _ = &v889;
    var v890: i64 = undefined; _ = &v890;
    var v891: i64 = undefined; _ = &v891;
    var v892: bool = undefined; _ = &v892;
    var v893: i64 = undefined; _ = &v893;
    var v894: i64 = undefined; _ = &v894;
    var v895: i64 = undefined; _ = &v895;
    var v896: i64 = undefined; _ = &v896;
    var v897: i64 = undefined; _ = &v897;
    var v898: i64 = undefined; _ = &v898;
    var v899: i64 = undefined; _ = &v899;
    var v900: []const u8 = undefined; _ = &v900;
    var v902: []const u8 = undefined; _ = &v902;
    var v923: i64 = undefined; _ = &v923;
    var v924: i64 = undefined; _ = &v924;
    var v927: i64 = undefined; _ = &v927;
    var v931: i64 = undefined; _ = &v931;
    var v908: i64 = undefined; _ = &v908;
    var v909: i64 = undefined; _ = &v909;
    var v910: i64 = undefined; _ = &v910;
    var v911: i64 = undefined; _ = &v911;
    var v912: i64 = undefined; _ = &v912;
    var v913: []const u8 = undefined; _ = &v913;
    var v905: i64 = undefined; _ = &v905;
    var v906: i64 = undefined; _ = &v906;
    var v907: []const u8 = undefined; _ = &v907;
    var v941: i64 = undefined; _ = &v941;
    var v945: i64 = undefined; _ = &v945;
    var v957: i64 = undefined; _ = &v957;
    var v973: i64 = undefined; _ = &v973;
    var v977: i64 = undefined; _ = &v977;
    var v989: i64 = undefined; _ = &v989;
    var v1014: i64 = undefined; _ = &v1014;
    var v1018: i64 = undefined; _ = &v1018;
    var v1030: i64 = undefined; _ = &v1030;
    var v1046: i64 = undefined; _ = &v1046;
    var v1050: i64 = undefined; _ = &v1050;
    var v1062: i64 = undefined; _ = &v1062;
    var v1079: i64 = undefined; _ = &v1079;
    var v1083: i64 = undefined; _ = &v1083;
    var v1095: i64 = undefined; _ = &v1095;
    var v1111: i64 = undefined; _ = &v1111;
    var v1115: i64 = undefined; _ = &v1115;
    var v1127: i64 = undefined; _ = &v1127;
    var v1144: i64 = undefined; _ = &v1144;
    var v1148: i64 = undefined; _ = &v1148;
    var v1160: i64 = undefined; _ = &v1160;
    var v1176: i64 = undefined; _ = &v1176;
    var v1180: i64 = undefined; _ = &v1180;
    var v1192: i64 = undefined; _ = &v1192;
    var v1208: i64 = undefined; _ = &v1208;
    var v1212: i64 = undefined; _ = &v1212;
    var v1224: i64 = undefined; _ = &v1224;
    var v1240: i64 = undefined; _ = &v1240;
    var v1244: i64 = undefined; _ = &v1244;
    var v1256: i64 = undefined; _ = &v1256;
    var v1280: i64 = undefined; _ = &v1280;
    var v1284: i64 = undefined; _ = &v1284;
    var v1296: i64 = undefined; _ = &v1296;
    var v1312: i64 = undefined; _ = &v1312;
    var v1316: i64 = undefined; _ = &v1316;
    var v1328: i64 = undefined; _ = &v1328;
    var v1344: i64 = undefined; _ = &v1344;
    var v1348: i64 = undefined; _ = &v1348;
    var v1360: i64 = undefined; _ = &v1360;
    var v1376: i64 = undefined; _ = &v1376;
    var v1380: i64 = undefined; _ = &v1380;
    var v1392: i64 = undefined; _ = &v1392;
    var v1408: i64 = undefined; _ = &v1408;
    var v1412: i64 = undefined; _ = &v1412;
    var v1424: i64 = undefined; _ = &v1424;
    var v1440: i64 = undefined; _ = &v1440;
    var v1444: i64 = undefined; _ = &v1444;
    var v1456: i64 = undefined; _ = &v1456;
    var v1477: i64 = undefined; _ = &v1477;
    var v1481: i64 = undefined; _ = &v1481;
    var v1493: i64 = undefined; _ = &v1493;
    var v1509: i64 = undefined; _ = &v1509;
    var v1513: i64 = undefined; _ = &v1513;
    var v1525: i64 = undefined; _ = &v1525;
    var v1541: i64 = undefined; _ = &v1541;
    var v1545: i64 = undefined; _ = &v1545;
    var v1557: i64 = undefined; _ = &v1557;
    var v1573: i64 = undefined; _ = &v1573;
    var v1577: i64 = undefined; _ = &v1577;
    var v1589: i64 = undefined; _ = &v1589;
    var v1605: i64 = undefined; _ = &v1605;
    var v1609: i64 = undefined; _ = &v1609;
    var v1621: i64 = undefined; _ = &v1621;
    var v1637: i64 = undefined; _ = &v1637;
    var v1641: i64 = undefined; _ = &v1641;
    var v1653: i64 = undefined; _ = &v1653;
    var v1677: i64 = undefined; _ = &v1677;
    var v1681: i64 = undefined; _ = &v1681;
    var v1693: i64 = undefined; _ = &v1693;
    var v1709: i64 = undefined; _ = &v1709;
    var v1713: i64 = undefined; _ = &v1713;
    var v1725: i64 = undefined; _ = &v1725;
    var v1742: i64 = undefined; _ = &v1742;
    var v1746: i64 = undefined; _ = &v1746;
    var v1758: i64 = undefined; _ = &v1758;
    var v1774: i64 = undefined; _ = &v1774;
    var v1778: i64 = undefined; _ = &v1778;
    var v1790: i64 = undefined; _ = &v1790;
    var v1806: i64 = undefined; _ = &v1806;
    var v1810: i64 = undefined; _ = &v1810;
    var v1822: i64 = undefined; _ = &v1822;
    var v1838: i64 = undefined; _ = &v1838;
    var v1842: i64 = undefined; _ = &v1842;
    var v1854: i64 = undefined; _ = &v1854;
    var v1874: i64 = undefined; _ = &v1874;
    var v1878: i64 = undefined; _ = &v1878;
    var v1890: i64 = undefined; _ = &v1890;
    var v1909: i64 = undefined; _ = &v1909;
    var v1913: i64 = undefined; _ = &v1913;
    var v1925: i64 = undefined; _ = &v1925;
    var v1972: US0 = undefined; _ = &v1972;
    var v1936: i64 = undefined; _ = &v1936;
    var v1937: i64 = undefined; _ = &v1937;
    var v1938: i64 = undefined; _ = &v1938;
    var v1939: i64 = undefined; _ = &v1939;
    var v1940: i64 = undefined; _ = &v1940;
    var v1941: i64 = undefined; _ = &v1941;
    var v1942: i64 = undefined; _ = &v1942;
    var v1943: i64 = undefined; _ = &v1943;
    var v1944: bool = undefined; _ = &v1944;
    var v1945: i64 = undefined; _ = &v1945;
    var v1946: i64 = undefined; _ = &v1946;
    var v1947: i64 = undefined; _ = &v1947;
    var v1948: bool = undefined; _ = &v1948;
    var v1949: i64 = undefined; _ = &v1949;
    var v1950: i64 = undefined; _ = &v1950;
    var v1951: i64 = undefined; _ = &v1951;
    var v1952: i64 = undefined; _ = &v1952;
    var v1953: i64 = undefined; _ = &v1953;
    var v1954: i64 = undefined; _ = &v1954;
    var v1955: i64 = undefined; _ = &v1955;
    var v1956: i64 = undefined; _ = &v1956;
    var v1957: i64 = undefined; _ = &v1957;
    var v1958: i64 = undefined; _ = &v1958;
    var v1959: i64 = undefined; _ = &v1959;
    var v1960: bool = undefined; _ = &v1960;
    var v1961: i64 = undefined; _ = &v1961;
    var v1962: i64 = undefined; _ = &v1962;
    var v1963: i64 = undefined; _ = &v1963;
    var v1964: i64 = undefined; _ = &v1964;
    var v1965: i64 = undefined; _ = &v1965;
    var v1966: i64 = undefined; _ = &v1966;
    var v1967: i64 = undefined; _ = &v1967;
    var v1968: []const u8 = undefined; _ = &v1968;
    var v1970: []const u8 = undefined; _ = &v1970;
    var v1991: i64 = undefined; _ = &v1991;
    var v1992: i64 = undefined; _ = &v1992;
    var v1995: i64 = undefined; _ = &v1995;
    var v1999: i64 = undefined; _ = &v1999;
    var v1976: i64 = undefined; _ = &v1976;
    var v1977: i64 = undefined; _ = &v1977;
    var v1978: i64 = undefined; _ = &v1978;
    var v1979: i64 = undefined; _ = &v1979;
    var v1980: i64 = undefined; _ = &v1980;
    var v1981: []const u8 = undefined; _ = &v1981;
    var v1973: i64 = undefined; _ = &v1973;
    var v1974: i64 = undefined; _ = &v1974;
    var v1975: []const u8 = undefined; _ = &v1975;
    var v2009: i64 = undefined; _ = &v2009;
    var v2013: i64 = undefined; _ = &v2013;
    var v2025: i64 = undefined; _ = &v2025;
    var v2041: i64 = undefined; _ = &v2041;
    var v2045: i64 = undefined; _ = &v2045;
    var v2057: i64 = undefined; _ = &v2057;
    var v2073: i64 = undefined; _ = &v2073;
    var v2077: i64 = undefined; _ = &v2077;
    var v2089: i64 = undefined; _ = &v2089;
    var v2105: i64 = undefined; _ = &v2105;
    var v2109: i64 = undefined; _ = &v2109;
    var v2121: i64 = undefined; _ = &v2121;
    var v2148: i64 = undefined; _ = &v2148;
    var v2152: i64 = undefined; _ = &v2152;
    var v2164: i64 = undefined; _ = &v2164;
    var v2180: i64 = undefined; _ = &v2180;
    var v2184: i64 = undefined; _ = &v2184;
    var v2196: i64 = undefined; _ = &v2196;
    var v2213: i64 = undefined; _ = &v2213;
    var v2217: i64 = undefined; _ = &v2217;
    var v2229: i64 = undefined; _ = &v2229;
    var v2245: i64 = undefined; _ = &v2245;
    var v2249: i64 = undefined; _ = &v2249;
    var v2261: i64 = undefined; _ = &v2261;
    var v2279: i64 = undefined; _ = &v2279;
    var v2283: i64 = undefined; _ = &v2283;
    var v2295: i64 = undefined; _ = &v2295;
    var v2314: i64 = undefined; _ = &v2314;
    var v2318: i64 = undefined; _ = &v2318;
    var v2330: i64 = undefined; _ = &v2330;
    var v2377: US0 = undefined; _ = &v2377;
    var v2341: i64 = undefined; _ = &v2341;
    var v2342: i64 = undefined; _ = &v2342;
    var v2343: i64 = undefined; _ = &v2343;
    var v2344: i64 = undefined; _ = &v2344;
    var v2345: i64 = undefined; _ = &v2345;
    var v2346: i64 = undefined; _ = &v2346;
    var v2347: i64 = undefined; _ = &v2347;
    var v2348: i64 = undefined; _ = &v2348;
    var v2349: bool = undefined; _ = &v2349;
    var v2350: i64 = undefined; _ = &v2350;
    var v2351: i64 = undefined; _ = &v2351;
    var v2352: i64 = undefined; _ = &v2352;
    var v2353: bool = undefined; _ = &v2353;
    var v2354: i64 = undefined; _ = &v2354;
    var v2355: i64 = undefined; _ = &v2355;
    var v2356: i64 = undefined; _ = &v2356;
    var v2357: i64 = undefined; _ = &v2357;
    var v2358: i64 = undefined; _ = &v2358;
    var v2359: i64 = undefined; _ = &v2359;
    var v2360: i64 = undefined; _ = &v2360;
    var v2361: i64 = undefined; _ = &v2361;
    var v2362: i64 = undefined; _ = &v2362;
    var v2363: i64 = undefined; _ = &v2363;
    var v2364: i64 = undefined; _ = &v2364;
    var v2365: bool = undefined; _ = &v2365;
    var v2366: i64 = undefined; _ = &v2366;
    var v2367: i64 = undefined; _ = &v2367;
    var v2368: i64 = undefined; _ = &v2368;
    var v2369: i64 = undefined; _ = &v2369;
    var v2370: i64 = undefined; _ = &v2370;
    var v2371: i64 = undefined; _ = &v2371;
    var v2372: i64 = undefined; _ = &v2372;
    var v2373: []const u8 = undefined; _ = &v2373;
    var v2375: []const u8 = undefined; _ = &v2375;
    var v2396: i64 = undefined; _ = &v2396;
    var v2397: i64 = undefined; _ = &v2397;
    var v2404: i64 = undefined; _ = &v2404;
    var v2381: i64 = undefined; _ = &v2381;
    var v2382: i64 = undefined; _ = &v2382;
    var v2383: i64 = undefined; _ = &v2383;
    var v2384: i64 = undefined; _ = &v2384;
    var v2385: i64 = undefined; _ = &v2385;
    var v2386: []const u8 = undefined; _ = &v2386;
    var v2378: i64 = undefined; _ = &v2378;
    var v2379: i64 = undefined; _ = &v2379;
    var v2380: []const u8 = undefined; _ = &v2380;
    var v2414: i64 = undefined; _ = &v2414;
    var v2418: i64 = undefined; _ = &v2418;
    var v2430: i64 = undefined; _ = &v2430;
    var v2446: i64 = undefined; _ = &v2446;
    var v2450: i64 = undefined; _ = &v2450;
    var v2462: i64 = undefined; _ = &v2462;
    var v2485: i64 = undefined; _ = &v2485;
    var v2489: i64 = undefined; _ = &v2489;
    var v2501: i64 = undefined; _ = &v2501;
    var v2517: i64 = undefined; _ = &v2517;
    var v2521: i64 = undefined; _ = &v2521;
    var v2533: i64 = undefined; _ = &v2533;
    var v2550: i64 = undefined; _ = &v2550;
    var v2554: i64 = undefined; _ = &v2554;
    var v2566: i64 = undefined; _ = &v2566;
    var v2582: i64 = undefined; _ = &v2582;
    var v2586: i64 = undefined; _ = &v2586;
    var v2598: i64 = undefined; _ = &v2598;
    var v2616: i64 = undefined; _ = &v2616;
    var v2620: i64 = undefined; _ = &v2620;
    var v2632: i64 = undefined; _ = &v2632;
    var v2651: i64 = undefined; _ = &v2651;
    var v2655: i64 = undefined; _ = &v2655;
    var v2667: i64 = undefined; _ = &v2667;
    var v2714: US0 = undefined; _ = &v2714;
    var v2678: i64 = undefined; _ = &v2678;
    var v2679: i64 = undefined; _ = &v2679;
    var v2680: i64 = undefined; _ = &v2680;
    var v2681: i64 = undefined; _ = &v2681;
    var v2682: i64 = undefined; _ = &v2682;
    var v2683: i64 = undefined; _ = &v2683;
    var v2684: i64 = undefined; _ = &v2684;
    var v2685: i64 = undefined; _ = &v2685;
    var v2686: bool = undefined; _ = &v2686;
    var v2687: i64 = undefined; _ = &v2687;
    var v2688: i64 = undefined; _ = &v2688;
    var v2689: i64 = undefined; _ = &v2689;
    var v2690: bool = undefined; _ = &v2690;
    var v2691: i64 = undefined; _ = &v2691;
    var v2692: i64 = undefined; _ = &v2692;
    var v2693: i64 = undefined; _ = &v2693;
    var v2694: i64 = undefined; _ = &v2694;
    var v2695: i64 = undefined; _ = &v2695;
    var v2696: i64 = undefined; _ = &v2696;
    var v2697: i64 = undefined; _ = &v2697;
    var v2698: i64 = undefined; _ = &v2698;
    var v2699: i64 = undefined; _ = &v2699;
    var v2700: i64 = undefined; _ = &v2700;
    var v2701: i64 = undefined; _ = &v2701;
    var v2702: bool = undefined; _ = &v2702;
    var v2703: i64 = undefined; _ = &v2703;
    var v2704: i64 = undefined; _ = &v2704;
    var v2705: i64 = undefined; _ = &v2705;
    var v2706: i64 = undefined; _ = &v2706;
    var v2707: i64 = undefined; _ = &v2707;
    var v2708: i64 = undefined; _ = &v2708;
    var v2709: i64 = undefined; _ = &v2709;
    var v2710: []const u8 = undefined; _ = &v2710;
    var v2712: []const u8 = undefined; _ = &v2712;
    var v2733: i64 = undefined; _ = &v2733;
    var v2734: i64 = undefined; _ = &v2734;
    var v2741: i64 = undefined; _ = &v2741;
    var v2718: i64 = undefined; _ = &v2718;
    var v2719: i64 = undefined; _ = &v2719;
    var v2720: i64 = undefined; _ = &v2720;
    var v2721: i64 = undefined; _ = &v2721;
    var v2722: i64 = undefined; _ = &v2722;
    var v2723: []const u8 = undefined; _ = &v2723;
    var v2715: i64 = undefined; _ = &v2715;
    var v2716: i64 = undefined; _ = &v2716;
    var v2717: []const u8 = undefined; _ = &v2717;
    var v2751: i64 = undefined; _ = &v2751;
    var v2755: i64 = undefined; _ = &v2755;
    var v2767: i64 = undefined; _ = &v2767;
    var v2783: i64 = undefined; _ = &v2783;
    var v2787: i64 = undefined; _ = &v2787;
    var v2799: i64 = undefined; _ = &v2799;
    var v2822: i64 = undefined; _ = &v2822;
    var v2826: i64 = undefined; _ = &v2826;
    var v2838: i64 = undefined; _ = &v2838;
    var v2854: i64 = undefined; _ = &v2854;
    var v2858: i64 = undefined; _ = &v2858;
    var v2870: i64 = undefined; _ = &v2870;
    var v2886: i64 = undefined; _ = &v2886;
    var v2890: i64 = undefined; _ = &v2890;
    var v2902: i64 = undefined; _ = &v2902;
    var v2918: i64 = undefined; _ = &v2918;
    var v2922: i64 = undefined; _ = &v2922;
    var v2934: i64 = undefined; _ = &v2934;
    var v2964: i64 = undefined; _ = &v2964;
    var v2968: i64 = undefined; _ = &v2968;
    var v2980: i64 = undefined; _ = &v2980;
    var v2996: i64 = undefined; _ = &v2996;
    var v3000: i64 = undefined; _ = &v3000;
    var v3012: i64 = undefined; _ = &v3012;
    var v3031: i64 = undefined; _ = &v3031;
    var v3035: i64 = undefined; _ = &v3035;
    var v3047: i64 = undefined; _ = &v3047;
    var v3063: i64 = undefined; _ = &v3063;
    var v3067: i64 = undefined; _ = &v3067;
    var v3079: i64 = undefined; _ = &v3079;
    var v3100: i64 = undefined; _ = &v3100;
    var v3104: i64 = undefined; _ = &v3104;
    var v3116: i64 = undefined; _ = &v3116;
    var v3132: i64 = undefined; _ = &v3132;
    var v3136: i64 = undefined; _ = &v3136;
    var v3148: i64 = undefined; _ = &v3148;
    var v3172: i64 = undefined; _ = &v3172;
    var v3176: i64 = undefined; _ = &v3176;
    var v3188: i64 = undefined; _ = &v3188;
    var v3209: i64 = undefined; _ = &v3209;
    var v3213: i64 = undefined; _ = &v3213;
    var v3225: i64 = undefined; _ = &v3225;
    var v3241: i64 = undefined; _ = &v3241;
    var v3245: i64 = undefined; _ = &v3245;
    var v3257: i64 = undefined; _ = &v3257;
    var v3284: i64 = undefined; _ = &v3284;
    var v3288: i64 = undefined; _ = &v3288;
    var v3300: i64 = undefined; _ = &v3300;
    var v3316: i64 = undefined; _ = &v3316;
    var v3320: i64 = undefined; _ = &v3320;
    var v3332: i64 = undefined; _ = &v3332;
    var v3356: i64 = undefined; _ = &v3356;
    var v3360: i64 = undefined; _ = &v3360;
    var v3372: i64 = undefined; _ = &v3372;
    var v3388: i64 = undefined; _ = &v3388;
    var v3392: i64 = undefined; _ = &v3392;
    var v3404: i64 = undefined; _ = &v3404;
    var v3423: i64 = undefined; _ = &v3423;
    var v3427: i64 = undefined; _ = &v3427;
    var v3439: i64 = undefined; _ = &v3439;
    var v3455: i64 = undefined; _ = &v3455;
    var v3459: i64 = undefined; _ = &v3459;
    var v3471: i64 = undefined; _ = &v3471;
    var v3495: i64 = undefined; _ = &v3495;
    var v3499: i64 = undefined; _ = &v3499;
    var v3511: i64 = undefined; _ = &v3511;
    var v3527: i64 = undefined; _ = &v3527;
    var v3531: i64 = undefined; _ = &v3531;
    var v3543: i64 = undefined; _ = &v3543;
    var v3559: i64 = undefined; _ = &v3559;
    var v3563: i64 = undefined; _ = &v3563;
    var v3575: i64 = undefined; _ = &v3575;
    var v3591: i64 = undefined; _ = &v3591;
    var v3595: i64 = undefined; _ = &v3595;
    var v3607: i64 = undefined; _ = &v3607;
    const v0: i64 = @as(i64, 0) + @as(i64, 1);
    const v1: i64 = v0 + @as(i64, 1);
    const v2: i64 = v1 + @as(i64, 1); _ = &v2;
    const v3: i64 = @as(i64, 0) + @as(i64, 1);
    const v4: i64 = v3 + @as(i64, 1);
    const v5: i64 = v4 + @as(i64, 1); _ = &v5;
    const v6: i64 = @as(i64, 0) + @as(i64, 1);
    const v7: i64 = v6 + @as(i64, 1);
    const v8: i64 = @as(i64, 0) + @as(i64, 1);
    const v9: i64 = v8 + @as(i64, 1);
    const v10: i64 = v9 + @as(i64, 1);
    const v11: i64 = v10 + @as(i64, 1); _ = &v11;
    const v12: i64 = @as(i64, 0) + @as(i64, 1);
    const v14: i64 = @as(i64, 0) + @as(i64, 1);
    const v15: i64 = v14 + @as(i64, 1);
    const v16: i64 = v15 + @as(i64, 1);
    const v17: i64 = v16 + @as(i64, 1);
    const v18: i64 = v17 + @as(i64, 1);
    const v19: i64 = @as(i64, 0) + @as(i64, 1);
    const v20: i64 = v12 +% v12;
    const v21: i64 = v7 +% v20;
    const v22: i64 = @as(i64, 0) + @as(i64, 1);
    const v23: i64 = v22 + @as(i64, 1);
    const v24: i64 = v23 + @as(i64, 1); _ = &v24;
    const v25: i64 = @as(i64, 0) + @as(i64, 1);
    const v26: i64 = v25 + @as(i64, 1);
    const v27: i64 = v26 + @as(i64, 1); _ = &v27;
    const v28: i64 = @as(i64, 0) + @as(i64, 1);
    const v29: i64 = v28 + @as(i64, 1);
    const v30: i64 = @as(i64, 0) + @as(i64, 1);
    const v31: i64 = v30 + @as(i64, 1);
    const v32: i64 = v31 + @as(i64, 1);
    const v33: i64 = v32 + @as(i64, 1); _ = &v33;
    const v34: i64 = @as(i64, 0) + @as(i64, 1);
    const v36: i64 = @as(i64, 0) + @as(i64, 1);
    const v37: i64 = v36 + @as(i64, 1);
    const v38: i64 = v37 + @as(i64, 1);
    const v39: i64 = v38 + @as(i64, 1);
    const v40: i64 = v34 +% v34;
    const v41: i64 = v29 +% v40;
    const v42: i64 = v18 +% v39;
    const v43: i64 = v21 +% v41;
    const v44: bool = v42 == @as(i64, 9);
    const v45: bool = v19 == @as(i64, 1);
    const v46: bool = v43 == @as(i64, 8);
    const v47: bool = (v44 and v45);
    const v48: bool = (v47 and v46);
    if (v48) {
    } else {
        if (spiral_true) spiralFail("typed-usd-eur-determined-tie-rounding-runtime-mismatch");
    }
    const v49: i64 = @as(i64, 0) + @as(i64, 1);
    const v50: i64 = v49 + @as(i64, 1);
    const v51: i64 = v50 + @as(i64, 1);
    const v52: i64 = v51 + @as(i64, 1);
    const v53: i64 = @as(i64, 0) + @as(i64, 1);
    const v54: i64 = v53 + @as(i64, 1);
    const v55: i64 = v54 + @as(i64, 1);
    const v56: i64 = v55 + @as(i64, 1);
    const v57: bool = v52 == v56;
    if (v57) {
        v58 = @as(i64, 0);
    } else {
        v58 = @as(i64, 1);
    }
    const v59: i64 = @as(i64, 0) + @as(i64, 1);
    const v60: i64 = @as(i64, 0) + @as(i64, 1);
    const v61: bool = v59 == v60;
    if (v61) {
        v62 = @as(i64, 0);
    } else {
        v62 = @as(i64, 1);
    }
    const v63: i64 = @as(i64, 0) + @as(i64, 1);
    const v64: i64 = v63 + @as(i64, 1);
    const v65: i64 = v64 + @as(i64, 1);
    const v66: i64 = v65 + @as(i64, 1);
    const v67: i64 = v66 + @as(i64, 1);
    const v68: i64 = @as(i64, 0) + @as(i64, 1);
    const v69: i64 = v68 + @as(i64, 1);
    const v70: i64 = v69 + @as(i64, 1);
    const v71: i64 = v70 + @as(i64, 1);
    const v72: i64 = v71 + @as(i64, 1);
    const v73: bool = v67 == v72;
    if (v73) {
        v74 = @as(i64, 0);
    } else {
        v74 = @as(i64, 1);
    }
    const v75: i64 = v59 +% v67;
    const v76: i64 = v60 +% v72;
    const v77: i64 = v62 +% v74;
    const v78: i64 = v52 +% v75;
    const v79: i64 = v56 +% v76;
    const v80: i64 = v58 +% v77;
    const v81: bool = v78 == @as(i64, 10);
    const v82: bool = v79 == @as(i64, 10);
    const v83: bool = v80 == @as(i64, 0);
    const v84: bool = (v81 and v82);
    const v85: bool = (v84 and v83);
    if (v85) {
    } else {
        if (spiral_true) spiralFail("typed-FX-statement-expected-raw-append-runtime-mismatch");
    }
    const v86: i64 = @as(i64, 0) + @as(i64, 1);
    const v87: i64 = v86 + @as(i64, 1);
    const v88: i64 = v87 + @as(i64, 1);
    const v89: i64 = v88 + @as(i64, 1);
    const v90: i64 = @as(i64, 0) + @as(i64, 1);
    const v91: i64 = v90 + @as(i64, 1);
    const v92: i64 = v91 + @as(i64, 1);
    const v93: i64 = v92 + @as(i64, 1);
    const v94: bool = v89 == v93;
    if (v94) {
        v95 = @as(i64, 0);
    } else {
        v95 = @as(i64, 1);
    }
    const v96: i64 = @as(i64, 0) + @as(i64, 1);
    const v97: i64 = @as(i64, 0) + @as(i64, 1);
    const v98: bool = v96 == v97;
    if (v98) {
        v99 = @as(i64, 0);
    } else {
        v99 = @as(i64, 1);
    }
    const v100: i64 = @as(i64, 0) + @as(i64, 1);
    const v101: i64 = v100 + @as(i64, 1);
    const v102: i64 = v101 + @as(i64, 1);
    const v103: i64 = v102 + @as(i64, 1);
    const v104: i64 = v103 + @as(i64, 1);
    const v105: i64 = @as(i64, 0) + @as(i64, 1);
    const v106: i64 = v105 + @as(i64, 1);
    const v107: i64 = v106 + @as(i64, 1);
    const v108: i64 = v107 + @as(i64, 1);
    const v109: i64 = v108 + @as(i64, 1);
    const v110: bool = v104 == v109;
    if (v110) {
        v111 = @as(i64, 0);
    } else {
        v111 = @as(i64, 1);
    }
    const v114: i64 = v99 +% v111;
    const v117: i64 = v95 +% v114;
    const v118: i64 = @as(i64, 0) + @as(i64, 1);
    const v119: i64 = v118 + @as(i64, 1);
    const v120: i64 = v119 + @as(i64, 1);
    const v121: i64 = v120 + @as(i64, 1);
    const v122: i64 = @as(i64, 0) + @as(i64, 1);
    const v123: i64 = v122 + @as(i64, 1);
    const v124: i64 = v123 + @as(i64, 1);
    const v125: i64 = v124 + @as(i64, 1);
    const v126: bool = v121 == v125;
    if (v126) {
        v127 = @as(i64, 0);
    } else {
        v127 = @as(i64, 1);
    }
    const v128: i64 = @as(i64, 0) + @as(i64, 1);
    const v129: i64 = @as(i64, 0) + @as(i64, 1);
    const v130: bool = v128 == v129;
    if (v130) {
        v131 = @as(i64, 0);
    } else {
        v131 = @as(i64, 1);
    }
    const v132: i64 = @as(i64, 0) + @as(i64, 1);
    const v133: i64 = v132 + @as(i64, 1);
    const v134: i64 = v133 + @as(i64, 1);
    const v135: i64 = v134 + @as(i64, 1);
    const v136: i64 = v135 + @as(i64, 1);
    const v137: i64 = @as(i64, 0) + @as(i64, 1);
    const v138: i64 = v137 + @as(i64, 1);
    const v139: i64 = v138 + @as(i64, 1);
    const v140: i64 = v139 + @as(i64, 1);
    const v141: i64 = v140 + @as(i64, 1);
    const v142: bool = v136 == v141;
    if (v142) {
        v143 = @as(i64, 0);
    } else {
        v143 = @as(i64, 1);
    }
    const v146: i64 = v131 +% v143;
    const v149: i64 = v127 +% v146;
    const v150: i64 = v117 +% v149;
    const v151: bool = v150 == @as(i64, 0);
    if (v151) {
    } else {
        if (spiral_true) spiralFail("typed-FX-statement-two-writer-raw-CAS-runtime-mismatch");
    }
    const v152: i64 = @as(i64, 0) + @as(i64, 1);
    const v153: i64 = v152 + @as(i64, 1);
    const v154: i64 = v153 + @as(i64, 1);
    const v155: i64 = v154 + @as(i64, 1);
    const v156: i64 = @as(i64, 0) + @as(i64, 1);
    const v157: i64 = v156 + @as(i64, 1);
    const v158: i64 = v157 + @as(i64, 1);
    const v159: i64 = v158 + @as(i64, 1);
    const v160: bool = v155 == v159;
    if (v160) {
        v161 = @as(i64, 0);
    } else {
        v161 = @as(i64, 1);
    }
    const v162: i64 = @as(i64, 0) + @as(i64, 1);
    const v163: i64 = @as(i64, 0) + @as(i64, 1);
    const v164: bool = v162 == v163;
    if (v164) {
        v165 = @as(i64, 0);
    } else {
        v165 = @as(i64, 1);
    }
    const v166: i64 = @as(i64, 0) + @as(i64, 1);
    const v167: i64 = v166 + @as(i64, 1);
    const v168: i64 = v167 + @as(i64, 1);
    const v169: i64 = v168 + @as(i64, 1);
    const v170: i64 = v169 + @as(i64, 1);
    const v171: i64 = @as(i64, 0) + @as(i64, 1);
    const v172: i64 = v171 + @as(i64, 1);
    const v173: i64 = v172 + @as(i64, 1);
    const v174: i64 = v173 + @as(i64, 1);
    const v175: i64 = v174 + @as(i64, 1);
    const v176: bool = v170 == v175;
    if (v176) {
        v177 = @as(i64, 0);
    } else {
        v177 = @as(i64, 1);
    }
    const v180: i64 = v165 +% v177;
    const v183: i64 = v161 +% v180;
    const v184: i64 = @as(i64, 0) + @as(i64, 1);
    const v185: i64 = v184 + @as(i64, 1);
    const v186: i64 = v185 + @as(i64, 1);
    const v187: i64 = v186 + @as(i64, 1);
    const v188: i64 = @as(i64, 0) + @as(i64, 1);
    const v189: i64 = v188 + @as(i64, 1);
    const v190: i64 = v189 + @as(i64, 1);
    const v191: i64 = v190 + @as(i64, 1);
    const v192: bool = v187 == v191;
    if (v192) {
        v193 = @as(i64, 0);
    } else {
        v193 = @as(i64, 1);
    }
    const v194: i64 = @as(i64, 0) + @as(i64, 1);
    const v195: i64 = @as(i64, 0) + @as(i64, 1);
    const v196: bool = v194 == v195;
    if (v196) {
        v197 = @as(i64, 0);
    } else {
        v197 = @as(i64, 1);
    }
    const v198: i64 = @as(i64, 0) + @as(i64, 1);
    const v199: i64 = v198 + @as(i64, 1);
    const v200: i64 = v199 + @as(i64, 1);
    const v201: i64 = v200 + @as(i64, 1);
    const v202: i64 = v201 + @as(i64, 1);
    const v203: i64 = @as(i64, 0) + @as(i64, 1);
    const v204: i64 = v203 + @as(i64, 1);
    const v205: i64 = v204 + @as(i64, 1);
    const v206: i64 = v205 + @as(i64, 1);
    const v207: i64 = v206 + @as(i64, 1);
    const v208: bool = v202 == v207;
    if (v208) {
        v209 = @as(i64, 0);
    } else {
        v209 = @as(i64, 1);
    }
    const v212: i64 = v197 +% v209;
    const v215: i64 = v193 +% v212;
    const v216: i64 = v183 +% v215;
    const v217: i64 = @as(i64, 0) + @as(i64, 1);
    const v218: i64 = v217 + @as(i64, 1);
    const v219: i64 = v218 + @as(i64, 1);
    const v220: i64 = v219 + @as(i64, 1);
    const v221: i64 = @as(i64, 0) + @as(i64, 1);
    const v222: i64 = v221 + @as(i64, 1);
    const v223: i64 = v222 + @as(i64, 1);
    const v224: i64 = v223 + @as(i64, 1);
    const v225: bool = v220 == v224;
    if (v225) {
        v226 = @as(i64, 0);
    } else {
        v226 = @as(i64, 1);
    }
    const v227: i64 = @as(i64, 0) + @as(i64, 1);
    const v228: i64 = @as(i64, 0) + @as(i64, 1);
    const v229: bool = v227 == v228;
    if (v229) {
        v230 = @as(i64, 0);
    } else {
        v230 = @as(i64, 1);
    }
    const v231: i64 = @as(i64, 0) + @as(i64, 1);
    const v232: i64 = v231 + @as(i64, 1);
    const v233: i64 = v232 + @as(i64, 1);
    const v234: i64 = v233 + @as(i64, 1);
    const v235: i64 = v234 + @as(i64, 1);
    const v236: i64 = @as(i64, 0) + @as(i64, 1);
    const v237: i64 = v236 + @as(i64, 1);
    const v238: i64 = v237 + @as(i64, 1);
    const v239: i64 = v238 + @as(i64, 1);
    const v240: i64 = v239 + @as(i64, 1);
    const v241: bool = v235 == v240;
    if (v241) {
        v242 = @as(i64, 0);
    } else {
        v242 = @as(i64, 1);
    }
    const v245: i64 = v230 +% v242;
    const v248: i64 = v226 +% v245;
    const v249: i64 = v216 +% v248;
    const v250: bool = v249 == @as(i64, 0);
    if (v250) {
    } else {
        if (spiral_true) spiralFail("typed-FX-statement-three-writer-raw-CAS-runtime-mismatch");
    }
    const v251: i64 = @as(i64, 0) + @as(i64, 1);
    const v252: i64 = v251 + @as(i64, 1);
    const v253: i64 = v252 + @as(i64, 1);
    const v254: i64 = v253 + @as(i64, 1);
    const v255: i64 = @as(i64, 0) + @as(i64, 1);
    const v256: i64 = v255 + @as(i64, 1);
    const v257: i64 = v256 + @as(i64, 1);
    const v258: i64 = v257 + @as(i64, 1);
    const v259: bool = v254 == v258;
    if (v259) {
        v260 = @as(i64, 0);
    } else {
        v260 = @as(i64, 1);
    }
    const v261: i64 = @as(i64, 0) + @as(i64, 1);
    const v262: i64 = @as(i64, 0) + @as(i64, 1);
    const v263: bool = v261 == v262;
    if (v263) {
        v264 = @as(i64, 0);
    } else {
        v264 = @as(i64, 1);
    }
    const v265: i64 = @as(i64, 0) + @as(i64, 1);
    const v266: i64 = v265 + @as(i64, 1);
    const v267: i64 = v266 + @as(i64, 1);
    const v268: i64 = v267 + @as(i64, 1);
    const v269: i64 = v268 + @as(i64, 1);
    const v270: i64 = @as(i64, 0) + @as(i64, 1);
    const v271: i64 = v270 + @as(i64, 1);
    const v272: i64 = v271 + @as(i64, 1);
    const v273: i64 = v272 + @as(i64, 1);
    const v274: i64 = v273 + @as(i64, 1);
    const v275: bool = v269 == v274;
    if (v275) {
        v276 = @as(i64, 0);
    } else {
        v276 = @as(i64, 1);
    }
    const v279: i64 = v264 +% v276;
    const v282: i64 = v260 +% v279;
    const v283: i64 = @as(i64, 0) + @as(i64, 1);
    const v284: i64 = v283 + @as(i64, 1);
    const v285: i64 = v284 + @as(i64, 1);
    const v286: i64 = v285 + @as(i64, 1);
    const v287: i64 = @as(i64, 0) + @as(i64, 1);
    const v288: i64 = v287 + @as(i64, 1);
    const v289: i64 = v288 + @as(i64, 1);
    const v290: i64 = v289 + @as(i64, 1);
    const v291: bool = v286 == v290;
    if (v291) {
        v292 = @as(i64, 0);
    } else {
        v292 = @as(i64, 1);
    }
    const v293: i64 = @as(i64, 0) + @as(i64, 1);
    const v294: i64 = @as(i64, 0) + @as(i64, 1);
    const v295: bool = v293 == v294;
    if (v295) {
        v296 = @as(i64, 0);
    } else {
        v296 = @as(i64, 1);
    }
    const v297: i64 = @as(i64, 0) + @as(i64, 1);
    const v298: i64 = v297 + @as(i64, 1);
    const v299: i64 = v298 + @as(i64, 1);
    const v300: i64 = v299 + @as(i64, 1);
    const v301: i64 = v300 + @as(i64, 1);
    const v302: i64 = @as(i64, 0) + @as(i64, 1);
    const v303: i64 = v302 + @as(i64, 1);
    const v304: i64 = v303 + @as(i64, 1);
    const v305: i64 = v304 + @as(i64, 1);
    const v306: i64 = v305 + @as(i64, 1);
    const v307: bool = v301 == v306;
    if (v307) {
        v308 = @as(i64, 0);
    } else {
        v308 = @as(i64, 1);
    }
    const v311: i64 = v296 +% v308;
    const v314: i64 = v292 +% v311;
    const v315: i64 = v282 +% v314;
    const v316: i64 = @as(i64, 0) + @as(i64, 1);
    const v317: i64 = v316 + @as(i64, 1);
    const v318: i64 = v317 + @as(i64, 1);
    const v319: i64 = v318 + @as(i64, 1);
    const v320: i64 = @as(i64, 0) + @as(i64, 1);
    const v321: i64 = v320 + @as(i64, 1);
    const v322: i64 = v321 + @as(i64, 1);
    const v323: i64 = v322 + @as(i64, 1);
    const v324: bool = v319 == v323;
    if (v324) {
        v325 = @as(i64, 0);
    } else {
        v325 = @as(i64, 1);
    }
    const v326: i64 = @as(i64, 0) + @as(i64, 1);
    const v327: i64 = @as(i64, 0) + @as(i64, 1);
    const v328: bool = v326 == v327;
    if (v328) {
        v329 = @as(i64, 0);
    } else {
        v329 = @as(i64, 1);
    }
    const v330: i64 = @as(i64, 0) + @as(i64, 1);
    const v331: i64 = v330 + @as(i64, 1);
    const v332: i64 = v331 + @as(i64, 1);
    const v333: i64 = v332 + @as(i64, 1);
    const v334: i64 = v333 + @as(i64, 1);
    const v335: i64 = @as(i64, 0) + @as(i64, 1);
    const v336: i64 = v335 + @as(i64, 1);
    const v337: i64 = v336 + @as(i64, 1);
    const v338: i64 = v337 + @as(i64, 1);
    const v339: i64 = v338 + @as(i64, 1);
    const v340: bool = v334 == v339;
    if (v340) {
        v341 = @as(i64, 0);
    } else {
        v341 = @as(i64, 1);
    }
    const v344: i64 = v329 +% v341;
    const v347: i64 = v325 +% v344;
    const v348: i64 = @as(i64, 0) + @as(i64, 1);
    const v349: i64 = v348 + @as(i64, 1);
    const v350: i64 = v349 + @as(i64, 1);
    const v351: i64 = v350 + @as(i64, 1);
    const v352: i64 = @as(i64, 0) + @as(i64, 1);
    const v353: i64 = v352 + @as(i64, 1);
    const v354: i64 = v353 + @as(i64, 1);
    const v355: i64 = v354 + @as(i64, 1);
    const v356: bool = v351 == v355;
    if (v356) {
        v357 = @as(i64, 0);
    } else {
        v357 = @as(i64, 1);
    }
    const v358: i64 = @as(i64, 0) + @as(i64, 1);
    const v359: i64 = @as(i64, 0) + @as(i64, 1);
    const v360: bool = v358 == v359;
    if (v360) {
        v361 = @as(i64, 0);
    } else {
        v361 = @as(i64, 1);
    }
    const v362: i64 = @as(i64, 0) + @as(i64, 1);
    const v363: i64 = v362 + @as(i64, 1);
    const v364: i64 = v363 + @as(i64, 1);
    const v365: i64 = v364 + @as(i64, 1);
    const v366: i64 = v365 + @as(i64, 1);
    const v367: i64 = @as(i64, 0) + @as(i64, 1);
    const v368: i64 = v367 + @as(i64, 1);
    const v369: i64 = v368 + @as(i64, 1);
    const v370: i64 = v369 + @as(i64, 1);
    const v371: i64 = v370 + @as(i64, 1);
    const v372: bool = v366 == v371;
    if (v372) {
        v373 = @as(i64, 0);
    } else {
        v373 = @as(i64, 1);
    }
    const v376: i64 = v361 +% v373;
    const v379: i64 = v357 +% v376;
    const v380: i64 = v347 +% v379;
    const v381: i64 = v315 +% v380;
    const v382: bool = v381 == @as(i64, 0);
    if (v382) {
    } else {
        if (spiral_true) spiralFail("typed-FX-statement-recursive-writer-raw-CAS-runtime-mismatch");
    }
    const v383: i64 = @as(i64, 0) + @as(i64, 1);
    const v384: i64 = v383 + @as(i64, 1);
    const v385: i64 = v384 + @as(i64, 1);
    const v386: i64 = v385 + @as(i64, 1);
    const v387: i64 = @as(i64, 0) + @as(i64, 1);
    const v388: i64 = v387 + @as(i64, 1);
    const v389: i64 = v388 + @as(i64, 1);
    const v390: i64 = v389 + @as(i64, 1);
    const v391: bool = v386 == v390;
    if (v391) {
        v392 = @as(i64, 0);
    } else {
        v392 = @as(i64, 1);
    }
    const v393: i64 = @as(i64, 0) + @as(i64, 1);
    const v394: i64 = @as(i64, 0) + @as(i64, 1);
    const v395: bool = v393 == v394;
    if (v395) {
        v396 = @as(i64, 0);
    } else {
        v396 = @as(i64, 1);
    }
    const v397: i64 = @as(i64, 0) + @as(i64, 1);
    const v398: i64 = v397 + @as(i64, 1);
    const v399: i64 = v398 + @as(i64, 1);
    const v400: i64 = v399 + @as(i64, 1);
    const v401: i64 = v400 + @as(i64, 1);
    const v402: i64 = @as(i64, 0) + @as(i64, 1);
    const v403: i64 = v402 + @as(i64, 1);
    const v404: i64 = v403 + @as(i64, 1);
    const v405: i64 = v404 + @as(i64, 1);
    const v406: i64 = v405 + @as(i64, 1);
    const v407: bool = v401 == v406;
    if (v407) {
        v408 = @as(i64, 0);
    } else {
        v408 = @as(i64, 1);
    }
    const v411: i64 = v396 +% v408;
    const v414: i64 = v392 +% v411;
    const v415: i64 = @as(i64, 0) + @as(i64, 1);
    const v416: i64 = v415 + @as(i64, 1);
    const v417: i64 = v416 + @as(i64, 1);
    const v418: i64 = v417 + @as(i64, 1);
    const v419: i64 = @as(i64, 0) + @as(i64, 1);
    const v420: i64 = v419 + @as(i64, 1);
    const v421: i64 = v420 + @as(i64, 1);
    const v422: i64 = v421 + @as(i64, 1);
    const v423: bool = v418 == v422;
    if (v423) {
        v424 = @as(i64, 0);
    } else {
        v424 = @as(i64, 1);
    }
    const v425: i64 = @as(i64, 0) + @as(i64, 1);
    const v426: i64 = @as(i64, 0) + @as(i64, 1);
    const v427: bool = v425 == v426;
    if (v427) {
        v428 = @as(i64, 0);
    } else {
        v428 = @as(i64, 1);
    }
    const v429: i64 = @as(i64, 0) + @as(i64, 1);
    const v430: i64 = v429 + @as(i64, 1);
    const v431: i64 = v430 + @as(i64, 1);
    const v432: i64 = v431 + @as(i64, 1);
    const v433: i64 = v432 + @as(i64, 1);
    const v434: i64 = @as(i64, 0) + @as(i64, 1);
    const v435: i64 = v434 + @as(i64, 1);
    const v436: i64 = v435 + @as(i64, 1);
    const v437: i64 = v436 + @as(i64, 1);
    const v438: i64 = v437 + @as(i64, 1);
    const v439: bool = v433 == v438;
    if (v439) {
        v440 = @as(i64, 0);
    } else {
        v440 = @as(i64, 1);
    }
    const v443: i64 = v428 +% v440;
    const v446: i64 = v424 +% v443;
    const v447: i64 = v414 +% v446;
    const v448: i64 = @as(i64, 0) + @as(i64, 1);
    const v449: i64 = v448 + @as(i64, 1);
    const v450: i64 = v449 + @as(i64, 1);
    const v451: i64 = v450 + @as(i64, 1);
    const v452: i64 = @as(i64, 0) + @as(i64, 1);
    const v453: i64 = v452 + @as(i64, 1);
    const v454: i64 = v453 + @as(i64, 1);
    const v455: i64 = v454 + @as(i64, 1);
    const v456: bool = v451 == v455;
    if (v456) {
        v457 = @as(i64, 0);
    } else {
        v457 = @as(i64, 1);
    }
    const v458: i64 = @as(i64, 0) + @as(i64, 1);
    const v459: i64 = @as(i64, 0) + @as(i64, 1);
    const v460: bool = v458 == v459;
    if (v460) {
        v461 = @as(i64, 0);
    } else {
        v461 = @as(i64, 1);
    }
    const v462: i64 = @as(i64, 0) + @as(i64, 1);
    const v463: i64 = v462 + @as(i64, 1);
    const v464: i64 = v463 + @as(i64, 1);
    const v465: i64 = v464 + @as(i64, 1);
    const v466: i64 = v465 + @as(i64, 1);
    const v467: i64 = @as(i64, 0) + @as(i64, 1);
    const v468: i64 = v467 + @as(i64, 1);
    const v469: i64 = v468 + @as(i64, 1);
    const v470: i64 = v469 + @as(i64, 1);
    const v471: i64 = v470 + @as(i64, 1);
    const v472: bool = v466 == v471;
    if (v472) {
        v473 = @as(i64, 0);
    } else {
        v473 = @as(i64, 1);
    }
    const v476: i64 = v461 +% v473;
    const v479: i64 = v457 +% v476;
    const v480: i64 = @as(i64, 0) + @as(i64, 1);
    const v481: i64 = v480 + @as(i64, 1);
    const v482: i64 = v481 + @as(i64, 1);
    const v483: i64 = v482 + @as(i64, 1);
    const v484: i64 = @as(i64, 0) + @as(i64, 1);
    const v485: i64 = v484 + @as(i64, 1);
    const v486: i64 = v485 + @as(i64, 1);
    const v487: i64 = v486 + @as(i64, 1);
    const v488: bool = v483 == v487;
    if (v488) {
        v489 = @as(i64, 0);
    } else {
        v489 = @as(i64, 1);
    }
    const v490: i64 = @as(i64, 0) + @as(i64, 1);
    const v491: i64 = @as(i64, 0) + @as(i64, 1);
    const v492: bool = v490 == v491;
    if (v492) {
        v493 = @as(i64, 0);
    } else {
        v493 = @as(i64, 1);
    }
    const v494: i64 = @as(i64, 0) + @as(i64, 1);
    const v495: i64 = v494 + @as(i64, 1);
    const v496: i64 = v495 + @as(i64, 1);
    const v497: i64 = v496 + @as(i64, 1);
    const v498: i64 = v497 + @as(i64, 1);
    const v499: i64 = @as(i64, 0) + @as(i64, 1);
    const v500: i64 = v499 + @as(i64, 1);
    const v501: i64 = v500 + @as(i64, 1);
    const v502: i64 = v501 + @as(i64, 1);
    const v503: i64 = v502 + @as(i64, 1);
    const v504: bool = v498 == v503;
    if (v504) {
        v505 = @as(i64, 0);
    } else {
        v505 = @as(i64, 1);
    }
    const v508: i64 = v493 +% v505;
    const v511: i64 = v489 +% v508;
    const v512: i64 = v479 +% v511;
    const v513: i64 = v447 +% v512;
    const v514: i64 = @as(i64, 0) + @as(i64, 1);
    const v515: i64 = v514 + @as(i64, 1);
    const v516: i64 = v515 + @as(i64, 1);
    const v517: i64 = v516 + @as(i64, 1);
    const v518: i64 = @as(i64, 0) + @as(i64, 1);
    const v519: i64 = v518 + @as(i64, 1);
    const v520: i64 = v519 + @as(i64, 1);
    const v521: i64 = v520 + @as(i64, 1);
    const v522: bool = v517 == v521;
    if (v522) {
        v523 = @as(i64, 0);
    } else {
        v523 = @as(i64, 1);
    }
    const v524: i64 = @as(i64, 0) + @as(i64, 1);
    const v525: i64 = @as(i64, 0) + @as(i64, 1);
    const v526: bool = v524 == v525;
    if (v526) {
        v527 = @as(i64, 0);
    } else {
        v527 = @as(i64, 1);
    }
    const v528: i64 = @as(i64, 0) + @as(i64, 1);
    const v529: i64 = v528 + @as(i64, 1);
    const v530: i64 = v529 + @as(i64, 1);
    const v531: i64 = v530 + @as(i64, 1);
    const v532: i64 = v531 + @as(i64, 1);
    const v533: i64 = @as(i64, 0) + @as(i64, 1);
    const v534: i64 = v533 + @as(i64, 1);
    const v535: i64 = v534 + @as(i64, 1);
    const v536: i64 = v535 + @as(i64, 1);
    const v537: i64 = v536 + @as(i64, 1);
    const v538: bool = v532 == v537;
    if (v538) {
        v539 = @as(i64, 0);
    } else {
        v539 = @as(i64, 1);
    }
    const v540: i64 = v524 +% v532;
    const v541: i64 = v525 +% v537;
    const v542: i64 = v527 +% v539;
    const v543: i64 = v517 +% v540;
    const v544: i64 = v521 +% v541;
    const v545: i64 = v523 +% v542;
    const v546: i64 = v544 +% v545;
    const v547: i64 = v543 +% v546;
    const v548: i64 = @as(i64, 3) +% v547;
    const v549: i64 = @as(i64, 0) + @as(i64, 1);
    const v550: i64 = v549 + @as(i64, 1);
    const v551: i64 = v550 + @as(i64, 1);
    const v552: i64 = v551 + @as(i64, 1);
    const v553: i64 = @as(i64, 0) + @as(i64, 1);
    const v554: i64 = v553 + @as(i64, 1);
    const v555: i64 = v554 + @as(i64, 1);
    const v556: i64 = v555 + @as(i64, 1);
    const v557: bool = v552 == v556;
    if (v557) {
        v558 = @as(i64, 0);
    } else {
        v558 = @as(i64, 1);
    }
    const v559: i64 = @as(i64, 0) + @as(i64, 1);
    const v560: i64 = @as(i64, 0) + @as(i64, 1);
    const v561: bool = v559 == v560;
    if (v561) {
        v562 = @as(i64, 0);
    } else {
        v562 = @as(i64, 1);
    }
    const v563: i64 = @as(i64, 0) + @as(i64, 1);
    const v564: i64 = v563 + @as(i64, 1);
    const v565: i64 = v564 + @as(i64, 1);
    const v566: i64 = v565 + @as(i64, 1);
    const v567: i64 = v566 + @as(i64, 1);
    const v568: i64 = @as(i64, 0) + @as(i64, 1);
    const v569: i64 = v568 + @as(i64, 1);
    const v570: i64 = v569 + @as(i64, 1);
    const v571: i64 = v570 + @as(i64, 1);
    const v572: i64 = v571 + @as(i64, 1);
    const v573: bool = v567 == v572;
    if (v573) {
        v574 = @as(i64, 0);
    } else {
        v574 = @as(i64, 1);
    }
    const v575: i64 = v559 +% v567;
    const v576: i64 = v560 +% v572;
    const v577: i64 = v562 +% v574;
    const v578: i64 = v552 +% v575;
    const v579: i64 = v556 +% v576;
    const v580: i64 = v558 +% v577;
    const v581: i64 = v579 +% v580;
    const v582: i64 = v578 +% v581;
    const v583: i64 = @as(i64, 3) +% v582;
    const v584: bool = v548 == v583;
    if (v584) {
        v585 = @as(i64, 0) + @as(i64, 1);
        v586 = v585 + @as(i64, 1);
        v587 = v586 + @as(i64, 1);
        v588 = v587 + @as(i64, 1);
        v589 = @as(i64, 0) + @as(i64, 1);
        v590 = v589 + @as(i64, 1);
        v591 = v590 + @as(i64, 1);
        v592 = v591 + @as(i64, 1);
        v593 = v588 == v592;
        if (v593) {
            v594 = @as(i64, 0);
        } else {
            v594 = @as(i64, 1);
        }
        v595 = @as(i64, 0) + @as(i64, 1);
        v596 = @as(i64, 0) + @as(i64, 1);
        v597 = v595 == v596;
        if (v597) {
            v598 = @as(i64, 0);
        } else {
            v598 = @as(i64, 1);
        }
        v599 = @as(i64, 0) + @as(i64, 1);
        v600 = v599 + @as(i64, 1);
        v601 = v600 + @as(i64, 1);
        v602 = v601 + @as(i64, 1);
        v603 = v602 + @as(i64, 1);
        v604 = @as(i64, 0) + @as(i64, 1);
        v605 = v604 + @as(i64, 1);
        v606 = v605 + @as(i64, 1);
        v607 = v606 + @as(i64, 1);
        v608 = v607 + @as(i64, 1);
        v609 = v603 == v608;
        if (v609) {
            v610 = @as(i64, 0);
        } else {
            v610 = @as(i64, 1);
        }
        v611 = v595 +% v603;
        v612 = v596 +% v608;
        v613 = v598 +% v610;
        v614 = v588 +% v611;
        v615 = v592 +% v612;
        v616 = v594 +% v613;
        v617 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation";
        v621 = US0_TypedFxHashedStatementChecksumValidationAccepted(@as(i64, 1), @as(i64, 3), v614, v615, v616, v617);
    } else {
        v619 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric";
        v621 = US0_TypedFxHashedStatementChecksumValidationRejected(v548, v583, v619);
    }
    switch (v621.tag) {
        0 => {
            v625 = v621.c0_0;
            v626 = v621.c0_1;
            v627 = v621.c0_2;
            v628 = v621.c0_3;
            v629 = v621.c0_4;
            v630 = v621.c0_5;
            v640 = @as(i64, 1);
            v641 = @as(i64, 0);
            v644 = v625;
            v645 = v626;
            v646 = v627;
            v647 = v628;
            v648 = v629;
        },
        1 => {
            v622 = v621.c1_0;
            v623 = v621.c1_1;
            v624 = v621.c1_2;
            v640 = @as(i64, 0);
            v641 = @as(i64, 1);
            v644 = @as(i64, 0);
            v645 = @as(i64, 0);
            v646 = @as(i64, 0);
            v647 = @as(i64, 0);
            v648 = @as(i64, 0);
        },
        else => unreachable,
    }
    const v649: bool = v513 == @as(i64, 0);
    const v650: bool = v548 == @as(i64, 23);
    const v651: bool = v640 == @as(i64, 1);
    const v652: bool = v641 == @as(i64, 0);
    const v653: bool = v644 == @as(i64, 1);
    const v654: bool = v645 == @as(i64, 3);
    const v655: bool = v646 == @as(i64, 10);
    const v656: bool = v647 == @as(i64, 10);
    const v657: bool = v648 == @as(i64, 0);
    const v658: bool = (v649 and v650);
    const v659: bool = (v658 and v651);
    const v660: bool = (v659 and v652);
    const v661: bool = (v660 and v653);
    const v662: bool = (v661 and v654);
    const v663: bool = (v662 and v655);
    const v664: bool = (v663 and v656);
    const v665: bool = (v664 and v657);
    if (v665) {
    } else {
        if (spiral_true) spiralFail("typed-FX-statement-recursive-writer-checksummed-restart-runtime-mismatch");
    }
    const v666: i64 = @as(i64, 0) + @as(i64, 1);
    const v667: i64 = v666 + @as(i64, 1);
    const v668: i64 = v667 + @as(i64, 1);
    const v669: i64 = v668 + @as(i64, 1);
    const v670: i64 = @as(i64, 0) + @as(i64, 1);
    const v671: i64 = v670 + @as(i64, 1);
    const v672: i64 = v671 + @as(i64, 1);
    const v673: i64 = v672 + @as(i64, 1);
    const v674: bool = v669 == v673;
    if (v674) {
        v675 = @as(i64, 0);
    } else {
        v675 = @as(i64, 1);
    }
    const v676: i64 = @as(i64, 0) + @as(i64, 1);
    const v677: i64 = @as(i64, 0) + @as(i64, 1);
    const v678: bool = v676 == v677;
    if (v678) {
        v679 = @as(i64, 0);
    } else {
        v679 = @as(i64, 1);
    }
    const v680: i64 = @as(i64, 0) + @as(i64, 1);
    const v681: i64 = v680 + @as(i64, 1);
    const v682: i64 = v681 + @as(i64, 1);
    const v683: i64 = v682 + @as(i64, 1);
    const v684: i64 = v683 + @as(i64, 1);
    const v685: i64 = @as(i64, 0) + @as(i64, 1);
    const v686: i64 = v685 + @as(i64, 1);
    const v687: i64 = v686 + @as(i64, 1);
    const v688: i64 = v687 + @as(i64, 1);
    const v689: i64 = v688 + @as(i64, 1);
    const v690: bool = v684 == v689;
    if (v690) {
        v691 = @as(i64, 0);
    } else {
        v691 = @as(i64, 1);
    }
    const v694: i64 = v679 +% v691;
    const v697: i64 = v675 +% v694;
    const v698: i64 = @as(i64, 0) + @as(i64, 1);
    const v699: i64 = v698 + @as(i64, 1);
    const v700: i64 = v699 + @as(i64, 1);
    const v701: i64 = v700 + @as(i64, 1);
    const v702: i64 = @as(i64, 0) + @as(i64, 1);
    const v703: i64 = v702 + @as(i64, 1);
    const v704: i64 = v703 + @as(i64, 1);
    const v705: i64 = v704 + @as(i64, 1);
    const v706: bool = v701 == v705;
    if (v706) {
        v707 = @as(i64, 0);
    } else {
        v707 = @as(i64, 1);
    }
    const v708: i64 = @as(i64, 0) + @as(i64, 1);
    const v709: i64 = @as(i64, 0) + @as(i64, 1);
    const v710: bool = v708 == v709;
    if (v710) {
        v711 = @as(i64, 0);
    } else {
        v711 = @as(i64, 1);
    }
    const v712: i64 = @as(i64, 0) + @as(i64, 1);
    const v713: i64 = v712 + @as(i64, 1);
    const v714: i64 = v713 + @as(i64, 1);
    const v715: i64 = v714 + @as(i64, 1);
    const v716: i64 = v715 + @as(i64, 1);
    const v717: i64 = @as(i64, 0) + @as(i64, 1);
    const v718: i64 = v717 + @as(i64, 1);
    const v719: i64 = v718 + @as(i64, 1);
    const v720: i64 = v719 + @as(i64, 1);
    const v721: i64 = v720 + @as(i64, 1);
    const v722: bool = v716 == v721;
    if (v722) {
        v723 = @as(i64, 0);
    } else {
        v723 = @as(i64, 1);
    }
    const v726: i64 = v711 +% v723;
    const v729: i64 = v707 +% v726;
    const v730: i64 = v697 +% v729;
    const v731: i64 = @as(i64, 0) + @as(i64, 1);
    const v732: i64 = v731 + @as(i64, 1);
    const v733: i64 = v732 + @as(i64, 1);
    const v734: i64 = v733 + @as(i64, 1);
    const v735: i64 = @as(i64, 0) + @as(i64, 1);
    const v736: i64 = v735 + @as(i64, 1);
    const v737: i64 = v736 + @as(i64, 1);
    const v738: i64 = v737 + @as(i64, 1);
    const v739: bool = v734 == v738;
    if (v739) {
        v740 = @as(i64, 0);
    } else {
        v740 = @as(i64, 1);
    }
    const v741: i64 = @as(i64, 0) + @as(i64, 1);
    const v742: i64 = @as(i64, 0) + @as(i64, 1);
    const v743: bool = v741 == v742;
    if (v743) {
        v744 = @as(i64, 0);
    } else {
        v744 = @as(i64, 1);
    }
    const v745: i64 = @as(i64, 0) + @as(i64, 1);
    const v746: i64 = v745 + @as(i64, 1);
    const v747: i64 = v746 + @as(i64, 1);
    const v748: i64 = v747 + @as(i64, 1);
    const v749: i64 = v748 + @as(i64, 1);
    const v750: i64 = @as(i64, 0) + @as(i64, 1);
    const v751: i64 = v750 + @as(i64, 1);
    const v752: i64 = v751 + @as(i64, 1);
    const v753: i64 = v752 + @as(i64, 1);
    const v754: i64 = v753 + @as(i64, 1);
    const v755: bool = v749 == v754;
    if (v755) {
        v756 = @as(i64, 0);
    } else {
        v756 = @as(i64, 1);
    }
    const v759: i64 = v744 +% v756;
    const v762: i64 = v740 +% v759;
    const v763: i64 = @as(i64, 0) + @as(i64, 1);
    const v764: i64 = v763 + @as(i64, 1);
    const v765: i64 = v764 + @as(i64, 1);
    const v766: i64 = v765 + @as(i64, 1);
    const v767: i64 = @as(i64, 0) + @as(i64, 1);
    const v768: i64 = v767 + @as(i64, 1);
    const v769: i64 = v768 + @as(i64, 1);
    const v770: i64 = v769 + @as(i64, 1);
    const v771: bool = v766 == v770;
    if (v771) {
        v772 = @as(i64, 0);
    } else {
        v772 = @as(i64, 1);
    }
    const v773: i64 = @as(i64, 0) + @as(i64, 1);
    const v774: i64 = @as(i64, 0) + @as(i64, 1);
    const v775: bool = v773 == v774;
    if (v775) {
        v776 = @as(i64, 0);
    } else {
        v776 = @as(i64, 1);
    }
    const v777: i64 = @as(i64, 0) + @as(i64, 1);
    const v778: i64 = v777 + @as(i64, 1);
    const v779: i64 = v778 + @as(i64, 1);
    const v780: i64 = v779 + @as(i64, 1);
    const v781: i64 = v780 + @as(i64, 1);
    const v782: i64 = @as(i64, 0) + @as(i64, 1);
    const v783: i64 = v782 + @as(i64, 1);
    const v784: i64 = v783 + @as(i64, 1);
    const v785: i64 = v784 + @as(i64, 1);
    const v786: i64 = v785 + @as(i64, 1);
    const v787: bool = v781 == v786;
    if (v787) {
        v788 = @as(i64, 0);
    } else {
        v788 = @as(i64, 1);
    }
    const v791: i64 = v776 +% v788;
    const v794: i64 = v772 +% v791;
    const v795: i64 = v762 +% v794;
    const v796: i64 = v730 +% v795;
    const v797: i64 = @as(i64, 0) + @as(i64, 1);
    const v798: i64 = v797 + @as(i64, 1);
    const v799: i64 = v798 + @as(i64, 1);
    const v800: i64 = v799 + @as(i64, 1);
    const v801: i64 = @as(i64, 0) + @as(i64, 1);
    const v802: i64 = v801 + @as(i64, 1);
    const v803: i64 = v802 + @as(i64, 1);
    const v804: i64 = v803 + @as(i64, 1);
    const v805: bool = v800 == v804;
    if (v805) {
        v806 = @as(i64, 0);
    } else {
        v806 = @as(i64, 1);
    }
    const v807: i64 = @as(i64, 0) + @as(i64, 1);
    const v808: i64 = @as(i64, 0) + @as(i64, 1);
    const v809: bool = v807 == v808;
    if (v809) {
        v810 = @as(i64, 0);
    } else {
        v810 = @as(i64, 1);
    }
    const v811: i64 = @as(i64, 0) + @as(i64, 1);
    const v812: i64 = v811 + @as(i64, 1);
    const v813: i64 = v812 + @as(i64, 1);
    const v814: i64 = v813 + @as(i64, 1);
    const v815: i64 = v814 + @as(i64, 1);
    const v816: i64 = @as(i64, 0) + @as(i64, 1);
    const v817: i64 = v816 + @as(i64, 1);
    const v818: i64 = v817 + @as(i64, 1);
    const v819: i64 = v818 + @as(i64, 1);
    const v820: i64 = v819 + @as(i64, 1);
    const v821: bool = v815 == v820;
    if (v821) {
        v822 = @as(i64, 0);
    } else {
        v822 = @as(i64, 1);
    }
    const v823: i64 = v807 +% v815;
    const v824: i64 = v808 +% v820;
    const v825: i64 = v810 +% v822;
    const v826: i64 = v800 +% v823;
    const v827: i64 = v804 +% v824;
    const v828: i64 = v806 +% v825;
    const v829: i64 = v827 +% v828;
    const v830: i64 = v826 +% v829;
    const v831: i64 = @as(i64, 3) +% v830;
    const v832: i64 = @as(i64, 0) + @as(i64, 1);
    const v833: i64 = v832 + @as(i64, 1);
    const v834: i64 = v833 + @as(i64, 1);
    const v835: i64 = v834 + @as(i64, 1);
    const v836: i64 = @as(i64, 0) + @as(i64, 1);
    const v837: i64 = v836 + @as(i64, 1);
    const v838: i64 = v837 + @as(i64, 1);
    const v839: i64 = v838 + @as(i64, 1);
    const v840: bool = v835 == v839;
    if (v840) {
        v841 = @as(i64, 0);
    } else {
        v841 = @as(i64, 1);
    }
    const v842: i64 = @as(i64, 0) + @as(i64, 1);
    const v843: i64 = @as(i64, 0) + @as(i64, 1);
    const v844: bool = v842 == v843;
    if (v844) {
        v845 = @as(i64, 0);
    } else {
        v845 = @as(i64, 1);
    }
    const v846: i64 = @as(i64, 0) + @as(i64, 1);
    const v847: i64 = v846 + @as(i64, 1);
    const v848: i64 = v847 + @as(i64, 1);
    const v849: i64 = v848 + @as(i64, 1);
    const v850: i64 = v849 + @as(i64, 1);
    const v851: i64 = @as(i64, 0) + @as(i64, 1);
    const v852: i64 = v851 + @as(i64, 1);
    const v853: i64 = v852 + @as(i64, 1);
    const v854: i64 = v853 + @as(i64, 1);
    const v855: i64 = v854 + @as(i64, 1);
    const v856: bool = v850 == v855;
    if (v856) {
        v857 = @as(i64, 0);
    } else {
        v857 = @as(i64, 1);
    }
    const v858: i64 = v842 +% v850;
    const v859: i64 = v843 +% v855;
    const v860: i64 = v845 +% v857;
    const v861: i64 = v835 +% v858;
    const v862: i64 = v839 +% v859;
    const v863: i64 = v841 +% v860;
    const v864: i64 = v862 +% v863;
    const v865: i64 = v861 +% v864;
    const v866: i64 = @as(i64, 3) +% v865;
    const v867: bool = v831 == v866;
    if (v867) {
        v868 = @as(i64, 0) + @as(i64, 1);
        v869 = v868 + @as(i64, 1);
        v870 = v869 + @as(i64, 1);
        v871 = v870 + @as(i64, 1);
        v872 = @as(i64, 0) + @as(i64, 1);
        v873 = v872 + @as(i64, 1);
        v874 = v873 + @as(i64, 1);
        v875 = v874 + @as(i64, 1);
        v876 = v871 == v875;
        if (v876) {
            v877 = @as(i64, 0);
        } else {
            v877 = @as(i64, 1);
        }
        v878 = @as(i64, 0) + @as(i64, 1);
        v879 = @as(i64, 0) + @as(i64, 1);
        v880 = v878 == v879;
        if (v880) {
            v881 = @as(i64, 0);
        } else {
            v881 = @as(i64, 1);
        }
        v882 = @as(i64, 0) + @as(i64, 1);
        v883 = v882 + @as(i64, 1);
        v884 = v883 + @as(i64, 1);
        v885 = v884 + @as(i64, 1);
        v886 = v885 + @as(i64, 1);
        v887 = @as(i64, 0) + @as(i64, 1);
        v888 = v887 + @as(i64, 1);
        v889 = v888 + @as(i64, 1);
        v890 = v889 + @as(i64, 1);
        v891 = v890 + @as(i64, 1);
        v892 = v886 == v891;
        if (v892) {
            v893 = @as(i64, 0);
        } else {
            v893 = @as(i64, 1);
        }
        v894 = v878 +% v886;
        v895 = v879 +% v891;
        v896 = v881 +% v893;
        v897 = v871 +% v894;
        v898 = v875 +% v895;
        v899 = v877 +% v896;
        v900 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation";
        v904 = US0_TypedFxHashedStatementChecksumValidationAccepted(@as(i64, 1), @as(i64, 3), v897, v898, v899, v900);
    } else {
        v902 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric";
        v904 = US0_TypedFxHashedStatementChecksumValidationRejected(v831, v866, v902);
    }
    switch (v904.tag) {
        0 => {
            v908 = v904.c0_0;
            v909 = v904.c0_1;
            v910 = v904.c0_2;
            v911 = v904.c0_3;
            v912 = v904.c0_4;
            v913 = v904.c0_5;
            v923 = @as(i64, 1);
            v924 = @as(i64, 0);
            v927 = v908;
            v931 = v912;
        },
        1 => {
            v905 = v904.c1_0;
            v906 = v904.c1_1;
            v907 = v904.c1_2;
            v923 = @as(i64, 0);
            v924 = @as(i64, 1);
            v927 = @as(i64, 0);
            v931 = @as(i64, 0);
        },
        else => unreachable,
    }
    const v932: i64 = @as(i64, 0) + @as(i64, 1);
    const v933: i64 = v932 + @as(i64, 1);
    const v934: i64 = v933 + @as(i64, 1);
    const v935: i64 = v934 + @as(i64, 1);
    const v936: i64 = @as(i64, 0) + @as(i64, 1);
    const v937: i64 = v936 + @as(i64, 1);
    const v938: i64 = v937 + @as(i64, 1);
    const v939: i64 = v938 + @as(i64, 1);
    const v940: bool = v935 == v939;
    if (v940) {
        v941 = @as(i64, 0);
    } else {
        v941 = @as(i64, 1);
    }
    const v942: i64 = @as(i64, 0) + @as(i64, 1);
    const v943: i64 = @as(i64, 0) + @as(i64, 1);
    const v944: bool = v942 == v943;
    if (v944) {
        v945 = @as(i64, 0);
    } else {
        v945 = @as(i64, 1);
    }
    const v946: i64 = @as(i64, 0) + @as(i64, 1);
    const v947: i64 = v946 + @as(i64, 1);
    const v948: i64 = v947 + @as(i64, 1);
    const v949: i64 = v948 + @as(i64, 1);
    const v950: i64 = v949 + @as(i64, 1);
    const v951: i64 = @as(i64, 0) + @as(i64, 1);
    const v952: i64 = v951 + @as(i64, 1);
    const v953: i64 = v952 + @as(i64, 1);
    const v954: i64 = v953 + @as(i64, 1);
    const v955: i64 = v954 + @as(i64, 1);
    const v956: bool = v950 == v955;
    if (v956) {
        v957 = @as(i64, 0);
    } else {
        v957 = @as(i64, 1);
    }
    const v960: i64 = v945 +% v957;
    const v963: i64 = v941 +% v960;
    const v964: i64 = @as(i64, 0) + @as(i64, 1);
    const v965: i64 = v964 + @as(i64, 1);
    const v966: i64 = v965 + @as(i64, 1);
    const v967: i64 = v966 + @as(i64, 1);
    const v968: i64 = @as(i64, 0) + @as(i64, 1);
    const v969: i64 = v968 + @as(i64, 1);
    const v970: i64 = v969 + @as(i64, 1);
    const v971: i64 = v970 + @as(i64, 1);
    const v972: bool = v967 == v971;
    if (v972) {
        v973 = @as(i64, 0);
    } else {
        v973 = @as(i64, 1);
    }
    const v974: i64 = @as(i64, 0) + @as(i64, 1);
    const v975: i64 = @as(i64, 0) + @as(i64, 1);
    const v976: bool = v974 == v975;
    if (v976) {
        v977 = @as(i64, 0);
    } else {
        v977 = @as(i64, 1);
    }
    const v978: i64 = @as(i64, 0) + @as(i64, 1);
    const v979: i64 = v978 + @as(i64, 1);
    const v980: i64 = v979 + @as(i64, 1);
    const v981: i64 = v980 + @as(i64, 1);
    const v982: i64 = v981 + @as(i64, 1);
    const v983: i64 = @as(i64, 0) + @as(i64, 1);
    const v984: i64 = v983 + @as(i64, 1);
    const v985: i64 = v984 + @as(i64, 1);
    const v986: i64 = v985 + @as(i64, 1);
    const v987: i64 = v986 + @as(i64, 1);
    const v988: bool = v982 == v987;
    if (v988) {
        v989 = @as(i64, 0);
    } else {
        v989 = @as(i64, 1);
    }
    const v992: i64 = v977 +% v989;
    const v995: i64 = v973 +% v992;
    const v996: i64 = v963 +% v995;
    const v997: i64 = v931 +% v924;
    const v998: i64 = v996 +% v997;
    const v999: i64 = v796 +% v998;
    const v1000: bool = v927 == @as(i64, 1);
    const v1001: bool = v923 == @as(i64, 1);
    const v1002: bool = v999 == @as(i64, 0);
    const v1003: bool = (v1000 and v1001);
    const v1004: bool = (v1003 and v1002);
    if (v1004) {
    } else {
        if (spiral_true) spiralFail("typed-FX-statement-recursive-writer-restart-invariant-runtime-mismatch");
    }
    const v1005: i64 = @as(i64, 0) + @as(i64, 1);
    const v1006: i64 = v1005 + @as(i64, 1);
    const v1007: i64 = v1006 + @as(i64, 1);
    const v1008: i64 = v1007 + @as(i64, 1);
    const v1009: i64 = @as(i64, 0) + @as(i64, 1);
    const v1010: i64 = v1009 + @as(i64, 1);
    const v1011: i64 = v1010 + @as(i64, 1);
    const v1012: i64 = v1011 + @as(i64, 1);
    const v1013: bool = v1008 == v1012;
    if (v1013) {
        v1014 = @as(i64, 0);
    } else {
        v1014 = @as(i64, 1);
    }
    const v1015: i64 = @as(i64, 0) + @as(i64, 1);
    const v1016: i64 = @as(i64, 0) + @as(i64, 1);
    const v1017: bool = v1015 == v1016;
    if (v1017) {
        v1018 = @as(i64, 0);
    } else {
        v1018 = @as(i64, 1);
    }
    const v1019: i64 = @as(i64, 0) + @as(i64, 1);
    const v1020: i64 = v1019 + @as(i64, 1);
    const v1021: i64 = v1020 + @as(i64, 1);
    const v1022: i64 = v1021 + @as(i64, 1);
    const v1023: i64 = v1022 + @as(i64, 1);
    const v1024: i64 = @as(i64, 0) + @as(i64, 1);
    const v1025: i64 = v1024 + @as(i64, 1);
    const v1026: i64 = v1025 + @as(i64, 1);
    const v1027: i64 = v1026 + @as(i64, 1);
    const v1028: i64 = v1027 + @as(i64, 1);
    const v1029: bool = v1023 == v1028;
    if (v1029) {
        v1030 = @as(i64, 0);
    } else {
        v1030 = @as(i64, 1);
    }
    const v1033: i64 = v1018 +% v1030;
    const v1036: i64 = v1014 +% v1033;
    const v1037: i64 = @as(i64, 0) + @as(i64, 1);
    const v1038: i64 = v1037 + @as(i64, 1);
    const v1039: i64 = v1038 + @as(i64, 1);
    const v1040: i64 = v1039 + @as(i64, 1);
    const v1041: i64 = @as(i64, 0) + @as(i64, 1);
    const v1042: i64 = v1041 + @as(i64, 1);
    const v1043: i64 = v1042 + @as(i64, 1);
    const v1044: i64 = v1043 + @as(i64, 1);
    const v1045: bool = v1040 == v1044;
    if (v1045) {
        v1046 = @as(i64, 0);
    } else {
        v1046 = @as(i64, 1);
    }
    const v1047: i64 = @as(i64, 0) + @as(i64, 1);
    const v1048: i64 = @as(i64, 0) + @as(i64, 1);
    const v1049: bool = v1047 == v1048;
    if (v1049) {
        v1050 = @as(i64, 0);
    } else {
        v1050 = @as(i64, 1);
    }
    const v1051: i64 = @as(i64, 0) + @as(i64, 1);
    const v1052: i64 = v1051 + @as(i64, 1);
    const v1053: i64 = v1052 + @as(i64, 1);
    const v1054: i64 = v1053 + @as(i64, 1);
    const v1055: i64 = v1054 + @as(i64, 1);
    const v1056: i64 = @as(i64, 0) + @as(i64, 1);
    const v1057: i64 = v1056 + @as(i64, 1);
    const v1058: i64 = v1057 + @as(i64, 1);
    const v1059: i64 = v1058 + @as(i64, 1);
    const v1060: i64 = v1059 + @as(i64, 1);
    const v1061: bool = v1055 == v1060;
    if (v1061) {
        v1062 = @as(i64, 0);
    } else {
        v1062 = @as(i64, 1);
    }
    const v1065: i64 = v1050 +% v1062;
    const v1068: i64 = v1046 +% v1065;
    const v1069: i64 = v1036 +% v1068;
    const v1070: i64 = @as(i64, 0) + @as(i64, 1);
    const v1071: i64 = v1070 + @as(i64, 1);
    const v1072: i64 = v1071 + @as(i64, 1);
    const v1073: i64 = v1072 + @as(i64, 1);
    const v1074: i64 = @as(i64, 0) + @as(i64, 1);
    const v1075: i64 = v1074 + @as(i64, 1);
    const v1076: i64 = v1075 + @as(i64, 1);
    const v1077: i64 = v1076 + @as(i64, 1);
    const v1078: bool = v1073 == v1077;
    if (v1078) {
        v1079 = @as(i64, 0);
    } else {
        v1079 = @as(i64, 1);
    }
    const v1080: i64 = @as(i64, 0) + @as(i64, 1);
    const v1081: i64 = @as(i64, 0) + @as(i64, 1);
    const v1082: bool = v1080 == v1081;
    if (v1082) {
        v1083 = @as(i64, 0);
    } else {
        v1083 = @as(i64, 1);
    }
    const v1084: i64 = @as(i64, 0) + @as(i64, 1);
    const v1085: i64 = v1084 + @as(i64, 1);
    const v1086: i64 = v1085 + @as(i64, 1);
    const v1087: i64 = v1086 + @as(i64, 1);
    const v1088: i64 = v1087 + @as(i64, 1);
    const v1089: i64 = @as(i64, 0) + @as(i64, 1);
    const v1090: i64 = v1089 + @as(i64, 1);
    const v1091: i64 = v1090 + @as(i64, 1);
    const v1092: i64 = v1091 + @as(i64, 1);
    const v1093: i64 = v1092 + @as(i64, 1);
    const v1094: bool = v1088 == v1093;
    if (v1094) {
        v1095 = @as(i64, 0);
    } else {
        v1095 = @as(i64, 1);
    }
    const v1098: i64 = v1083 +% v1095;
    const v1101: i64 = v1079 +% v1098;
    const v1102: i64 = @as(i64, 0) + @as(i64, 1);
    const v1103: i64 = v1102 + @as(i64, 1);
    const v1104: i64 = v1103 + @as(i64, 1);
    const v1105: i64 = v1104 + @as(i64, 1);
    const v1106: i64 = @as(i64, 0) + @as(i64, 1);
    const v1107: i64 = v1106 + @as(i64, 1);
    const v1108: i64 = v1107 + @as(i64, 1);
    const v1109: i64 = v1108 + @as(i64, 1);
    const v1110: bool = v1105 == v1109;
    if (v1110) {
        v1111 = @as(i64, 0);
    } else {
        v1111 = @as(i64, 1);
    }
    const v1112: i64 = @as(i64, 0) + @as(i64, 1);
    const v1113: i64 = @as(i64, 0) + @as(i64, 1);
    const v1114: bool = v1112 == v1113;
    if (v1114) {
        v1115 = @as(i64, 0);
    } else {
        v1115 = @as(i64, 1);
    }
    const v1116: i64 = @as(i64, 0) + @as(i64, 1);
    const v1117: i64 = v1116 + @as(i64, 1);
    const v1118: i64 = v1117 + @as(i64, 1);
    const v1119: i64 = v1118 + @as(i64, 1);
    const v1120: i64 = v1119 + @as(i64, 1);
    const v1121: i64 = @as(i64, 0) + @as(i64, 1);
    const v1122: i64 = v1121 + @as(i64, 1);
    const v1123: i64 = v1122 + @as(i64, 1);
    const v1124: i64 = v1123 + @as(i64, 1);
    const v1125: i64 = v1124 + @as(i64, 1);
    const v1126: bool = v1120 == v1125;
    if (v1126) {
        v1127 = @as(i64, 0);
    } else {
        v1127 = @as(i64, 1);
    }
    const v1130: i64 = v1115 +% v1127;
    const v1133: i64 = v1111 +% v1130;
    const v1134: i64 = v1101 +% v1133;
    const v1135: i64 = @as(i64, 0) + @as(i64, 1);
    const v1136: i64 = v1135 + @as(i64, 1);
    const v1137: i64 = v1136 + @as(i64, 1);
    const v1138: i64 = v1137 + @as(i64, 1);
    const v1139: i64 = @as(i64, 0) + @as(i64, 1);
    const v1140: i64 = v1139 + @as(i64, 1);
    const v1141: i64 = v1140 + @as(i64, 1);
    const v1142: i64 = v1141 + @as(i64, 1);
    const v1143: bool = v1138 == v1142;
    if (v1143) {
        v1144 = @as(i64, 0);
    } else {
        v1144 = @as(i64, 1);
    }
    const v1145: i64 = @as(i64, 0) + @as(i64, 1);
    const v1146: i64 = @as(i64, 0) + @as(i64, 1);
    const v1147: bool = v1145 == v1146;
    if (v1147) {
        v1148 = @as(i64, 0);
    } else {
        v1148 = @as(i64, 1);
    }
    const v1149: i64 = @as(i64, 0) + @as(i64, 1);
    const v1150: i64 = v1149 + @as(i64, 1);
    const v1151: i64 = v1150 + @as(i64, 1);
    const v1152: i64 = v1151 + @as(i64, 1);
    const v1153: i64 = v1152 + @as(i64, 1);
    const v1154: i64 = @as(i64, 0) + @as(i64, 1);
    const v1155: i64 = v1154 + @as(i64, 1);
    const v1156: i64 = v1155 + @as(i64, 1);
    const v1157: i64 = v1156 + @as(i64, 1);
    const v1158: i64 = v1157 + @as(i64, 1);
    const v1159: bool = v1153 == v1158;
    if (v1159) {
        v1160 = @as(i64, 0);
    } else {
        v1160 = @as(i64, 1);
    }
    const v1163: i64 = v1148 +% v1160;
    const v1166: i64 = v1144 +% v1163;
    const v1167: i64 = @as(i64, 0) + @as(i64, 1);
    const v1168: i64 = v1167 + @as(i64, 1);
    const v1169: i64 = v1168 + @as(i64, 1);
    const v1170: i64 = v1169 + @as(i64, 1);
    const v1171: i64 = @as(i64, 0) + @as(i64, 1);
    const v1172: i64 = v1171 + @as(i64, 1);
    const v1173: i64 = v1172 + @as(i64, 1);
    const v1174: i64 = v1173 + @as(i64, 1);
    const v1175: bool = v1170 == v1174;
    if (v1175) {
        v1176 = @as(i64, 0);
    } else {
        v1176 = @as(i64, 1);
    }
    const v1177: i64 = @as(i64, 0) + @as(i64, 1);
    const v1178: i64 = @as(i64, 0) + @as(i64, 1);
    const v1179: bool = v1177 == v1178;
    if (v1179) {
        v1180 = @as(i64, 0);
    } else {
        v1180 = @as(i64, 1);
    }
    const v1181: i64 = @as(i64, 0) + @as(i64, 1);
    const v1182: i64 = v1181 + @as(i64, 1);
    const v1183: i64 = v1182 + @as(i64, 1);
    const v1184: i64 = v1183 + @as(i64, 1);
    const v1185: i64 = v1184 + @as(i64, 1);
    const v1186: i64 = @as(i64, 0) + @as(i64, 1);
    const v1187: i64 = v1186 + @as(i64, 1);
    const v1188: i64 = v1187 + @as(i64, 1);
    const v1189: i64 = v1188 + @as(i64, 1);
    const v1190: i64 = v1189 + @as(i64, 1);
    const v1191: bool = v1185 == v1190;
    if (v1191) {
        v1192 = @as(i64, 0);
    } else {
        v1192 = @as(i64, 1);
    }
    const v1195: i64 = v1180 +% v1192;
    const v1198: i64 = v1176 +% v1195;
    const v1199: i64 = @as(i64, 0) + @as(i64, 1);
    const v1200: i64 = v1199 + @as(i64, 1);
    const v1201: i64 = v1200 + @as(i64, 1);
    const v1202: i64 = v1201 + @as(i64, 1);
    const v1203: i64 = @as(i64, 0) + @as(i64, 1);
    const v1204: i64 = v1203 + @as(i64, 1);
    const v1205: i64 = v1204 + @as(i64, 1);
    const v1206: i64 = v1205 + @as(i64, 1);
    const v1207: bool = v1202 == v1206;
    if (v1207) {
        v1208 = @as(i64, 0);
    } else {
        v1208 = @as(i64, 1);
    }
    const v1209: i64 = @as(i64, 0) + @as(i64, 1);
    const v1210: i64 = @as(i64, 0) + @as(i64, 1);
    const v1211: bool = v1209 == v1210;
    if (v1211) {
        v1212 = @as(i64, 0);
    } else {
        v1212 = @as(i64, 1);
    }
    const v1213: i64 = @as(i64, 0) + @as(i64, 1);
    const v1214: i64 = v1213 + @as(i64, 1);
    const v1215: i64 = v1214 + @as(i64, 1);
    const v1216: i64 = v1215 + @as(i64, 1);
    const v1217: i64 = v1216 + @as(i64, 1);
    const v1218: i64 = @as(i64, 0) + @as(i64, 1);
    const v1219: i64 = v1218 + @as(i64, 1);
    const v1220: i64 = v1219 + @as(i64, 1);
    const v1221: i64 = v1220 + @as(i64, 1);
    const v1222: i64 = v1221 + @as(i64, 1);
    const v1223: bool = v1217 == v1222;
    if (v1223) {
        v1224 = @as(i64, 0);
    } else {
        v1224 = @as(i64, 1);
    }
    const v1227: i64 = v1212 +% v1224;
    const v1230: i64 = v1208 +% v1227;
    const v1231: i64 = @as(i64, 0) + @as(i64, 1);
    const v1232: i64 = v1231 + @as(i64, 1);
    const v1233: i64 = v1232 + @as(i64, 1);
    const v1234: i64 = v1233 + @as(i64, 1);
    const v1235: i64 = @as(i64, 0) + @as(i64, 1);
    const v1236: i64 = v1235 + @as(i64, 1);
    const v1237: i64 = v1236 + @as(i64, 1);
    const v1238: i64 = v1237 + @as(i64, 1);
    const v1239: bool = v1234 == v1238;
    if (v1239) {
        v1240 = @as(i64, 0);
    } else {
        v1240 = @as(i64, 1);
    }
    const v1241: i64 = @as(i64, 0) + @as(i64, 1);
    const v1242: i64 = @as(i64, 0) + @as(i64, 1);
    const v1243: bool = v1241 == v1242;
    if (v1243) {
        v1244 = @as(i64, 0);
    } else {
        v1244 = @as(i64, 1);
    }
    const v1245: i64 = @as(i64, 0) + @as(i64, 1);
    const v1246: i64 = v1245 + @as(i64, 1);
    const v1247: i64 = v1246 + @as(i64, 1);
    const v1248: i64 = v1247 + @as(i64, 1);
    const v1249: i64 = v1248 + @as(i64, 1);
    const v1250: i64 = @as(i64, 0) + @as(i64, 1);
    const v1251: i64 = v1250 + @as(i64, 1);
    const v1252: i64 = v1251 + @as(i64, 1);
    const v1253: i64 = v1252 + @as(i64, 1);
    const v1254: i64 = v1253 + @as(i64, 1);
    const v1255: bool = v1249 == v1254;
    if (v1255) {
        v1256 = @as(i64, 0);
    } else {
        v1256 = @as(i64, 1);
    }
    const v1259: i64 = v1244 +% v1256;
    const v1262: i64 = v1240 +% v1259;
    const v1263: i64 = v1230 +% v1262;
    const v1264: i64 = v1198 +% v1263;
    const v1265: i64 = v1166 +% v1264;
    const v1266: bool = v1069 == @as(i64, 0);
    const v1267: bool = v1134 == v1069;
    const v1268: bool = v1265 == @as(i64, 0);
    const v1269: bool = (v1266 and v1267);
    const v1270: bool = (v1269 and v1268);
    if (v1270) {
    } else {
        if (spiral_true) spiralFail("typed-FX-statement-stale-writer-conflict-program-append-runtime-mismatch");
    }
    const v1271: i64 = @as(i64, 0) + @as(i64, 1);
    const v1272: i64 = v1271 + @as(i64, 1);
    const v1273: i64 = v1272 + @as(i64, 1);
    const v1274: i64 = v1273 + @as(i64, 1);
    const v1275: i64 = @as(i64, 0) + @as(i64, 1);
    const v1276: i64 = v1275 + @as(i64, 1);
    const v1277: i64 = v1276 + @as(i64, 1);
    const v1278: i64 = v1277 + @as(i64, 1);
    const v1279: bool = v1274 == v1278;
    if (v1279) {
        v1280 = @as(i64, 0);
    } else {
        v1280 = @as(i64, 1);
    }
    const v1281: i64 = @as(i64, 0) + @as(i64, 1);
    const v1282: i64 = @as(i64, 0) + @as(i64, 1);
    const v1283: bool = v1281 == v1282;
    if (v1283) {
        v1284 = @as(i64, 0);
    } else {
        v1284 = @as(i64, 1);
    }
    const v1285: i64 = @as(i64, 0) + @as(i64, 1);
    const v1286: i64 = v1285 + @as(i64, 1);
    const v1287: i64 = v1286 + @as(i64, 1);
    const v1288: i64 = v1287 + @as(i64, 1);
    const v1289: i64 = v1288 + @as(i64, 1);
    const v1290: i64 = @as(i64, 0) + @as(i64, 1);
    const v1291: i64 = v1290 + @as(i64, 1);
    const v1292: i64 = v1291 + @as(i64, 1);
    const v1293: i64 = v1292 + @as(i64, 1);
    const v1294: i64 = v1293 + @as(i64, 1);
    const v1295: bool = v1289 == v1294;
    if (v1295) {
        v1296 = @as(i64, 0);
    } else {
        v1296 = @as(i64, 1);
    }
    const v1299: i64 = v1284 +% v1296;
    const v1302: i64 = v1280 +% v1299;
    const v1303: i64 = @as(i64, 0) + @as(i64, 1);
    const v1304: i64 = v1303 + @as(i64, 1);
    const v1305: i64 = v1304 + @as(i64, 1);
    const v1306: i64 = v1305 + @as(i64, 1);
    const v1307: i64 = @as(i64, 0) + @as(i64, 1);
    const v1308: i64 = v1307 + @as(i64, 1);
    const v1309: i64 = v1308 + @as(i64, 1);
    const v1310: i64 = v1309 + @as(i64, 1);
    const v1311: bool = v1306 == v1310;
    if (v1311) {
        v1312 = @as(i64, 0);
    } else {
        v1312 = @as(i64, 1);
    }
    const v1313: i64 = @as(i64, 0) + @as(i64, 1);
    const v1314: i64 = @as(i64, 0) + @as(i64, 1);
    const v1315: bool = v1313 == v1314;
    if (v1315) {
        v1316 = @as(i64, 0);
    } else {
        v1316 = @as(i64, 1);
    }
    const v1317: i64 = @as(i64, 0) + @as(i64, 1);
    const v1318: i64 = v1317 + @as(i64, 1);
    const v1319: i64 = v1318 + @as(i64, 1);
    const v1320: i64 = v1319 + @as(i64, 1);
    const v1321: i64 = v1320 + @as(i64, 1);
    const v1322: i64 = @as(i64, 0) + @as(i64, 1);
    const v1323: i64 = v1322 + @as(i64, 1);
    const v1324: i64 = v1323 + @as(i64, 1);
    const v1325: i64 = v1324 + @as(i64, 1);
    const v1326: i64 = v1325 + @as(i64, 1);
    const v1327: bool = v1321 == v1326;
    if (v1327) {
        v1328 = @as(i64, 0);
    } else {
        v1328 = @as(i64, 1);
    }
    const v1331: i64 = v1316 +% v1328;
    const v1334: i64 = v1312 +% v1331;
    const v1335: i64 = @as(i64, 0) + @as(i64, 1);
    const v1336: i64 = v1335 + @as(i64, 1);
    const v1337: i64 = v1336 + @as(i64, 1);
    const v1338: i64 = v1337 + @as(i64, 1);
    const v1339: i64 = @as(i64, 0) + @as(i64, 1);
    const v1340: i64 = v1339 + @as(i64, 1);
    const v1341: i64 = v1340 + @as(i64, 1);
    const v1342: i64 = v1341 + @as(i64, 1);
    const v1343: bool = v1338 == v1342;
    if (v1343) {
        v1344 = @as(i64, 0);
    } else {
        v1344 = @as(i64, 1);
    }
    const v1345: i64 = @as(i64, 0) + @as(i64, 1);
    const v1346: i64 = @as(i64, 0) + @as(i64, 1);
    const v1347: bool = v1345 == v1346;
    if (v1347) {
        v1348 = @as(i64, 0);
    } else {
        v1348 = @as(i64, 1);
    }
    const v1349: i64 = @as(i64, 0) + @as(i64, 1);
    const v1350: i64 = v1349 + @as(i64, 1);
    const v1351: i64 = v1350 + @as(i64, 1);
    const v1352: i64 = v1351 + @as(i64, 1);
    const v1353: i64 = v1352 + @as(i64, 1);
    const v1354: i64 = @as(i64, 0) + @as(i64, 1);
    const v1355: i64 = v1354 + @as(i64, 1);
    const v1356: i64 = v1355 + @as(i64, 1);
    const v1357: i64 = v1356 + @as(i64, 1);
    const v1358: i64 = v1357 + @as(i64, 1);
    const v1359: bool = v1353 == v1358;
    if (v1359) {
        v1360 = @as(i64, 0);
    } else {
        v1360 = @as(i64, 1);
    }
    const v1363: i64 = v1348 +% v1360;
    const v1366: i64 = v1344 +% v1363;
    const v1367: i64 = @as(i64, 0) + @as(i64, 1);
    const v1368: i64 = v1367 + @as(i64, 1);
    const v1369: i64 = v1368 + @as(i64, 1);
    const v1370: i64 = v1369 + @as(i64, 1);
    const v1371: i64 = @as(i64, 0) + @as(i64, 1);
    const v1372: i64 = v1371 + @as(i64, 1);
    const v1373: i64 = v1372 + @as(i64, 1);
    const v1374: i64 = v1373 + @as(i64, 1);
    const v1375: bool = v1370 == v1374;
    if (v1375) {
        v1376 = @as(i64, 0);
    } else {
        v1376 = @as(i64, 1);
    }
    const v1377: i64 = @as(i64, 0) + @as(i64, 1);
    const v1378: i64 = @as(i64, 0) + @as(i64, 1);
    const v1379: bool = v1377 == v1378;
    if (v1379) {
        v1380 = @as(i64, 0);
    } else {
        v1380 = @as(i64, 1);
    }
    const v1381: i64 = @as(i64, 0) + @as(i64, 1);
    const v1382: i64 = v1381 + @as(i64, 1);
    const v1383: i64 = v1382 + @as(i64, 1);
    const v1384: i64 = v1383 + @as(i64, 1);
    const v1385: i64 = v1384 + @as(i64, 1);
    const v1386: i64 = @as(i64, 0) + @as(i64, 1);
    const v1387: i64 = v1386 + @as(i64, 1);
    const v1388: i64 = v1387 + @as(i64, 1);
    const v1389: i64 = v1388 + @as(i64, 1);
    const v1390: i64 = v1389 + @as(i64, 1);
    const v1391: bool = v1385 == v1390;
    if (v1391) {
        v1392 = @as(i64, 0);
    } else {
        v1392 = @as(i64, 1);
    }
    const v1395: i64 = v1380 +% v1392;
    const v1398: i64 = v1376 +% v1395;
    const v1399: i64 = @as(i64, 0) + @as(i64, 1);
    const v1400: i64 = v1399 + @as(i64, 1);
    const v1401: i64 = v1400 + @as(i64, 1);
    const v1402: i64 = v1401 + @as(i64, 1);
    const v1403: i64 = @as(i64, 0) + @as(i64, 1);
    const v1404: i64 = v1403 + @as(i64, 1);
    const v1405: i64 = v1404 + @as(i64, 1);
    const v1406: i64 = v1405 + @as(i64, 1);
    const v1407: bool = v1402 == v1406;
    if (v1407) {
        v1408 = @as(i64, 0);
    } else {
        v1408 = @as(i64, 1);
    }
    const v1409: i64 = @as(i64, 0) + @as(i64, 1);
    const v1410: i64 = @as(i64, 0) + @as(i64, 1);
    const v1411: bool = v1409 == v1410;
    if (v1411) {
        v1412 = @as(i64, 0);
    } else {
        v1412 = @as(i64, 1);
    }
    const v1413: i64 = @as(i64, 0) + @as(i64, 1);
    const v1414: i64 = v1413 + @as(i64, 1);
    const v1415: i64 = v1414 + @as(i64, 1);
    const v1416: i64 = v1415 + @as(i64, 1);
    const v1417: i64 = v1416 + @as(i64, 1);
    const v1418: i64 = @as(i64, 0) + @as(i64, 1);
    const v1419: i64 = v1418 + @as(i64, 1);
    const v1420: i64 = v1419 + @as(i64, 1);
    const v1421: i64 = v1420 + @as(i64, 1);
    const v1422: i64 = v1421 + @as(i64, 1);
    const v1423: bool = v1417 == v1422;
    if (v1423) {
        v1424 = @as(i64, 0);
    } else {
        v1424 = @as(i64, 1);
    }
    const v1427: i64 = v1412 +% v1424;
    const v1430: i64 = v1408 +% v1427;
    const v1431: i64 = @as(i64, 0) + @as(i64, 1);
    const v1432: i64 = v1431 + @as(i64, 1);
    const v1433: i64 = v1432 + @as(i64, 1);
    const v1434: i64 = v1433 + @as(i64, 1);
    const v1435: i64 = @as(i64, 0) + @as(i64, 1);
    const v1436: i64 = v1435 + @as(i64, 1);
    const v1437: i64 = v1436 + @as(i64, 1);
    const v1438: i64 = v1437 + @as(i64, 1);
    const v1439: bool = v1434 == v1438;
    if (v1439) {
        v1440 = @as(i64, 0);
    } else {
        v1440 = @as(i64, 1);
    }
    const v1441: i64 = @as(i64, 0) + @as(i64, 1);
    const v1442: i64 = @as(i64, 0) + @as(i64, 1);
    const v1443: bool = v1441 == v1442;
    if (v1443) {
        v1444 = @as(i64, 0);
    } else {
        v1444 = @as(i64, 1);
    }
    const v1445: i64 = @as(i64, 0) + @as(i64, 1);
    const v1446: i64 = v1445 + @as(i64, 1);
    const v1447: i64 = v1446 + @as(i64, 1);
    const v1448: i64 = v1447 + @as(i64, 1);
    const v1449: i64 = v1448 + @as(i64, 1);
    const v1450: i64 = @as(i64, 0) + @as(i64, 1);
    const v1451: i64 = v1450 + @as(i64, 1);
    const v1452: i64 = v1451 + @as(i64, 1);
    const v1453: i64 = v1452 + @as(i64, 1);
    const v1454: i64 = v1453 + @as(i64, 1);
    const v1455: bool = v1449 == v1454;
    if (v1455) {
        v1456 = @as(i64, 0);
    } else {
        v1456 = @as(i64, 1);
    }
    const v1459: i64 = v1444 +% v1456;
    const v1462: i64 = v1440 +% v1459;
    const v1463: i64 = v1430 +% v1462;
    const v1464: i64 = v1398 +% v1463;
    const v1465: i64 = v1366 +% v1464;
    const v1466: i64 = v1334 +% v1465;
    const v1467: i64 = v1302 +% v1466;
    const v1468: i64 = @as(i64, 0) + @as(i64, 1);
    const v1469: i64 = v1468 + @as(i64, 1);
    const v1470: i64 = v1469 + @as(i64, 1);
    const v1471: i64 = v1470 + @as(i64, 1);
    const v1472: i64 = @as(i64, 0) + @as(i64, 1);
    const v1473: i64 = v1472 + @as(i64, 1);
    const v1474: i64 = v1473 + @as(i64, 1);
    const v1475: i64 = v1474 + @as(i64, 1);
    const v1476: bool = v1471 == v1475;
    if (v1476) {
        v1477 = @as(i64, 0);
    } else {
        v1477 = @as(i64, 1);
    }
    const v1478: i64 = @as(i64, 0) + @as(i64, 1);
    const v1479: i64 = @as(i64, 0) + @as(i64, 1);
    const v1480: bool = v1478 == v1479;
    if (v1480) {
        v1481 = @as(i64, 0);
    } else {
        v1481 = @as(i64, 1);
    }
    const v1482: i64 = @as(i64, 0) + @as(i64, 1);
    const v1483: i64 = v1482 + @as(i64, 1);
    const v1484: i64 = v1483 + @as(i64, 1);
    const v1485: i64 = v1484 + @as(i64, 1);
    const v1486: i64 = v1485 + @as(i64, 1);
    const v1487: i64 = @as(i64, 0) + @as(i64, 1);
    const v1488: i64 = v1487 + @as(i64, 1);
    const v1489: i64 = v1488 + @as(i64, 1);
    const v1490: i64 = v1489 + @as(i64, 1);
    const v1491: i64 = v1490 + @as(i64, 1);
    const v1492: bool = v1486 == v1491;
    if (v1492) {
        v1493 = @as(i64, 0);
    } else {
        v1493 = @as(i64, 1);
    }
    const v1496: i64 = v1481 +% v1493;
    const v1499: i64 = v1477 +% v1496;
    const v1500: i64 = @as(i64, 0) + @as(i64, 1);
    const v1501: i64 = v1500 + @as(i64, 1);
    const v1502: i64 = v1501 + @as(i64, 1);
    const v1503: i64 = v1502 + @as(i64, 1);
    const v1504: i64 = @as(i64, 0) + @as(i64, 1);
    const v1505: i64 = v1504 + @as(i64, 1);
    const v1506: i64 = v1505 + @as(i64, 1);
    const v1507: i64 = v1506 + @as(i64, 1);
    const v1508: bool = v1503 == v1507;
    if (v1508) {
        v1509 = @as(i64, 0);
    } else {
        v1509 = @as(i64, 1);
    }
    const v1510: i64 = @as(i64, 0) + @as(i64, 1);
    const v1511: i64 = @as(i64, 0) + @as(i64, 1);
    const v1512: bool = v1510 == v1511;
    if (v1512) {
        v1513 = @as(i64, 0);
    } else {
        v1513 = @as(i64, 1);
    }
    const v1514: i64 = @as(i64, 0) + @as(i64, 1);
    const v1515: i64 = v1514 + @as(i64, 1);
    const v1516: i64 = v1515 + @as(i64, 1);
    const v1517: i64 = v1516 + @as(i64, 1);
    const v1518: i64 = v1517 + @as(i64, 1);
    const v1519: i64 = @as(i64, 0) + @as(i64, 1);
    const v1520: i64 = v1519 + @as(i64, 1);
    const v1521: i64 = v1520 + @as(i64, 1);
    const v1522: i64 = v1521 + @as(i64, 1);
    const v1523: i64 = v1522 + @as(i64, 1);
    const v1524: bool = v1518 == v1523;
    if (v1524) {
        v1525 = @as(i64, 0);
    } else {
        v1525 = @as(i64, 1);
    }
    const v1528: i64 = v1513 +% v1525;
    const v1531: i64 = v1509 +% v1528;
    const v1532: i64 = @as(i64, 0) + @as(i64, 1);
    const v1533: i64 = v1532 + @as(i64, 1);
    const v1534: i64 = v1533 + @as(i64, 1);
    const v1535: i64 = v1534 + @as(i64, 1);
    const v1536: i64 = @as(i64, 0) + @as(i64, 1);
    const v1537: i64 = v1536 + @as(i64, 1);
    const v1538: i64 = v1537 + @as(i64, 1);
    const v1539: i64 = v1538 + @as(i64, 1);
    const v1540: bool = v1535 == v1539;
    if (v1540) {
        v1541 = @as(i64, 0);
    } else {
        v1541 = @as(i64, 1);
    }
    const v1542: i64 = @as(i64, 0) + @as(i64, 1);
    const v1543: i64 = @as(i64, 0) + @as(i64, 1);
    const v1544: bool = v1542 == v1543;
    if (v1544) {
        v1545 = @as(i64, 0);
    } else {
        v1545 = @as(i64, 1);
    }
    const v1546: i64 = @as(i64, 0) + @as(i64, 1);
    const v1547: i64 = v1546 + @as(i64, 1);
    const v1548: i64 = v1547 + @as(i64, 1);
    const v1549: i64 = v1548 + @as(i64, 1);
    const v1550: i64 = v1549 + @as(i64, 1);
    const v1551: i64 = @as(i64, 0) + @as(i64, 1);
    const v1552: i64 = v1551 + @as(i64, 1);
    const v1553: i64 = v1552 + @as(i64, 1);
    const v1554: i64 = v1553 + @as(i64, 1);
    const v1555: i64 = v1554 + @as(i64, 1);
    const v1556: bool = v1550 == v1555;
    if (v1556) {
        v1557 = @as(i64, 0);
    } else {
        v1557 = @as(i64, 1);
    }
    const v1560: i64 = v1545 +% v1557;
    const v1563: i64 = v1541 +% v1560;
    const v1564: i64 = @as(i64, 0) + @as(i64, 1);
    const v1565: i64 = v1564 + @as(i64, 1);
    const v1566: i64 = v1565 + @as(i64, 1);
    const v1567: i64 = v1566 + @as(i64, 1);
    const v1568: i64 = @as(i64, 0) + @as(i64, 1);
    const v1569: i64 = v1568 + @as(i64, 1);
    const v1570: i64 = v1569 + @as(i64, 1);
    const v1571: i64 = v1570 + @as(i64, 1);
    const v1572: bool = v1567 == v1571;
    if (v1572) {
        v1573 = @as(i64, 0);
    } else {
        v1573 = @as(i64, 1);
    }
    const v1574: i64 = @as(i64, 0) + @as(i64, 1);
    const v1575: i64 = @as(i64, 0) + @as(i64, 1);
    const v1576: bool = v1574 == v1575;
    if (v1576) {
        v1577 = @as(i64, 0);
    } else {
        v1577 = @as(i64, 1);
    }
    const v1578: i64 = @as(i64, 0) + @as(i64, 1);
    const v1579: i64 = v1578 + @as(i64, 1);
    const v1580: i64 = v1579 + @as(i64, 1);
    const v1581: i64 = v1580 + @as(i64, 1);
    const v1582: i64 = v1581 + @as(i64, 1);
    const v1583: i64 = @as(i64, 0) + @as(i64, 1);
    const v1584: i64 = v1583 + @as(i64, 1);
    const v1585: i64 = v1584 + @as(i64, 1);
    const v1586: i64 = v1585 + @as(i64, 1);
    const v1587: i64 = v1586 + @as(i64, 1);
    const v1588: bool = v1582 == v1587;
    if (v1588) {
        v1589 = @as(i64, 0);
    } else {
        v1589 = @as(i64, 1);
    }
    const v1592: i64 = v1577 +% v1589;
    const v1595: i64 = v1573 +% v1592;
    const v1596: i64 = @as(i64, 0) + @as(i64, 1);
    const v1597: i64 = v1596 + @as(i64, 1);
    const v1598: i64 = v1597 + @as(i64, 1);
    const v1599: i64 = v1598 + @as(i64, 1);
    const v1600: i64 = @as(i64, 0) + @as(i64, 1);
    const v1601: i64 = v1600 + @as(i64, 1);
    const v1602: i64 = v1601 + @as(i64, 1);
    const v1603: i64 = v1602 + @as(i64, 1);
    const v1604: bool = v1599 == v1603;
    if (v1604) {
        v1605 = @as(i64, 0);
    } else {
        v1605 = @as(i64, 1);
    }
    const v1606: i64 = @as(i64, 0) + @as(i64, 1);
    const v1607: i64 = @as(i64, 0) + @as(i64, 1);
    const v1608: bool = v1606 == v1607;
    if (v1608) {
        v1609 = @as(i64, 0);
    } else {
        v1609 = @as(i64, 1);
    }
    const v1610: i64 = @as(i64, 0) + @as(i64, 1);
    const v1611: i64 = v1610 + @as(i64, 1);
    const v1612: i64 = v1611 + @as(i64, 1);
    const v1613: i64 = v1612 + @as(i64, 1);
    const v1614: i64 = v1613 + @as(i64, 1);
    const v1615: i64 = @as(i64, 0) + @as(i64, 1);
    const v1616: i64 = v1615 + @as(i64, 1);
    const v1617: i64 = v1616 + @as(i64, 1);
    const v1618: i64 = v1617 + @as(i64, 1);
    const v1619: i64 = v1618 + @as(i64, 1);
    const v1620: bool = v1614 == v1619;
    if (v1620) {
        v1621 = @as(i64, 0);
    } else {
        v1621 = @as(i64, 1);
    }
    const v1624: i64 = v1609 +% v1621;
    const v1627: i64 = v1605 +% v1624;
    const v1628: i64 = @as(i64, 0) + @as(i64, 1);
    const v1629: i64 = v1628 + @as(i64, 1);
    const v1630: i64 = v1629 + @as(i64, 1);
    const v1631: i64 = v1630 + @as(i64, 1);
    const v1632: i64 = @as(i64, 0) + @as(i64, 1);
    const v1633: i64 = v1632 + @as(i64, 1);
    const v1634: i64 = v1633 + @as(i64, 1);
    const v1635: i64 = v1634 + @as(i64, 1);
    const v1636: bool = v1631 == v1635;
    if (v1636) {
        v1637 = @as(i64, 0);
    } else {
        v1637 = @as(i64, 1);
    }
    const v1638: i64 = @as(i64, 0) + @as(i64, 1);
    const v1639: i64 = @as(i64, 0) + @as(i64, 1);
    const v1640: bool = v1638 == v1639;
    if (v1640) {
        v1641 = @as(i64, 0);
    } else {
        v1641 = @as(i64, 1);
    }
    const v1642: i64 = @as(i64, 0) + @as(i64, 1);
    const v1643: i64 = v1642 + @as(i64, 1);
    const v1644: i64 = v1643 + @as(i64, 1);
    const v1645: i64 = v1644 + @as(i64, 1);
    const v1646: i64 = v1645 + @as(i64, 1);
    const v1647: i64 = @as(i64, 0) + @as(i64, 1);
    const v1648: i64 = v1647 + @as(i64, 1);
    const v1649: i64 = v1648 + @as(i64, 1);
    const v1650: i64 = v1649 + @as(i64, 1);
    const v1651: i64 = v1650 + @as(i64, 1);
    const v1652: bool = v1646 == v1651;
    if (v1652) {
        v1653 = @as(i64, 0);
    } else {
        v1653 = @as(i64, 1);
    }
    const v1656: i64 = v1641 +% v1653;
    const v1659: i64 = v1637 +% v1656;
    const v1660: i64 = v1627 +% v1659;
    const v1661: i64 = v1595 +% v1660;
    const v1662: i64 = v1563 +% v1661;
    const v1663: i64 = v1531 +% v1662;
    const v1664: i64 = v1499 +% v1663;
    const v1665: bool = v1467 == @as(i64, 0);
    const v1666: bool = v1664 == v1467;
    const v1667: bool = (v1665 and v1666);
    if (v1667) {
    } else {
        if (spiral_true) spiralFail("typed-FX-statement-stale-writer-conflict-program-append-associativity-runtime-mismatch");
    }
    const v1668: i64 = @as(i64, 0) + @as(i64, 1);
    const v1669: i64 = v1668 + @as(i64, 1);
    const v1670: i64 = v1669 + @as(i64, 1);
    const v1671: i64 = v1670 + @as(i64, 1);
    const v1672: i64 = @as(i64, 0) + @as(i64, 1);
    const v1673: i64 = v1672 + @as(i64, 1);
    const v1674: i64 = v1673 + @as(i64, 1);
    const v1675: i64 = v1674 + @as(i64, 1);
    const v1676: bool = v1671 == v1675;
    if (v1676) {
        v1677 = @as(i64, 0);
    } else {
        v1677 = @as(i64, 1);
    }
    const v1678: i64 = @as(i64, 0) + @as(i64, 1);
    const v1679: i64 = @as(i64, 0) + @as(i64, 1);
    const v1680: bool = v1678 == v1679;
    if (v1680) {
        v1681 = @as(i64, 0);
    } else {
        v1681 = @as(i64, 1);
    }
    const v1682: i64 = @as(i64, 0) + @as(i64, 1);
    const v1683: i64 = v1682 + @as(i64, 1);
    const v1684: i64 = v1683 + @as(i64, 1);
    const v1685: i64 = v1684 + @as(i64, 1);
    const v1686: i64 = v1685 + @as(i64, 1);
    const v1687: i64 = @as(i64, 0) + @as(i64, 1);
    const v1688: i64 = v1687 + @as(i64, 1);
    const v1689: i64 = v1688 + @as(i64, 1);
    const v1690: i64 = v1689 + @as(i64, 1);
    const v1691: i64 = v1690 + @as(i64, 1);
    const v1692: bool = v1686 == v1691;
    if (v1692) {
        v1693 = @as(i64, 0);
    } else {
        v1693 = @as(i64, 1);
    }
    const v1696: i64 = v1681 +% v1693;
    const v1699: i64 = v1677 +% v1696;
    const v1700: i64 = @as(i64, 0) + @as(i64, 1);
    const v1701: i64 = v1700 + @as(i64, 1);
    const v1702: i64 = v1701 + @as(i64, 1);
    const v1703: i64 = v1702 + @as(i64, 1);
    const v1704: i64 = @as(i64, 0) + @as(i64, 1);
    const v1705: i64 = v1704 + @as(i64, 1);
    const v1706: i64 = v1705 + @as(i64, 1);
    const v1707: i64 = v1706 + @as(i64, 1);
    const v1708: bool = v1703 == v1707;
    if (v1708) {
        v1709 = @as(i64, 0);
    } else {
        v1709 = @as(i64, 1);
    }
    const v1710: i64 = @as(i64, 0) + @as(i64, 1);
    const v1711: i64 = @as(i64, 0) + @as(i64, 1);
    const v1712: bool = v1710 == v1711;
    if (v1712) {
        v1713 = @as(i64, 0);
    } else {
        v1713 = @as(i64, 1);
    }
    const v1714: i64 = @as(i64, 0) + @as(i64, 1);
    const v1715: i64 = v1714 + @as(i64, 1);
    const v1716: i64 = v1715 + @as(i64, 1);
    const v1717: i64 = v1716 + @as(i64, 1);
    const v1718: i64 = v1717 + @as(i64, 1);
    const v1719: i64 = @as(i64, 0) + @as(i64, 1);
    const v1720: i64 = v1719 + @as(i64, 1);
    const v1721: i64 = v1720 + @as(i64, 1);
    const v1722: i64 = v1721 + @as(i64, 1);
    const v1723: i64 = v1722 + @as(i64, 1);
    const v1724: bool = v1718 == v1723;
    if (v1724) {
        v1725 = @as(i64, 0);
    } else {
        v1725 = @as(i64, 1);
    }
    const v1728: i64 = v1713 +% v1725;
    const v1731: i64 = v1709 +% v1728;
    const v1732: i64 = v1699 +% v1731;
    const v1733: i64 = @as(i64, 0) + @as(i64, 1);
    const v1734: i64 = v1733 + @as(i64, 1);
    const v1735: i64 = v1734 + @as(i64, 1);
    const v1736: i64 = v1735 + @as(i64, 1);
    const v1737: i64 = @as(i64, 0) + @as(i64, 1);
    const v1738: i64 = v1737 + @as(i64, 1);
    const v1739: i64 = v1738 + @as(i64, 1);
    const v1740: i64 = v1739 + @as(i64, 1);
    const v1741: bool = v1736 == v1740;
    if (v1741) {
        v1742 = @as(i64, 0);
    } else {
        v1742 = @as(i64, 1);
    }
    const v1743: i64 = @as(i64, 0) + @as(i64, 1);
    const v1744: i64 = @as(i64, 0) + @as(i64, 1);
    const v1745: bool = v1743 == v1744;
    if (v1745) {
        v1746 = @as(i64, 0);
    } else {
        v1746 = @as(i64, 1);
    }
    const v1747: i64 = @as(i64, 0) + @as(i64, 1);
    const v1748: i64 = v1747 + @as(i64, 1);
    const v1749: i64 = v1748 + @as(i64, 1);
    const v1750: i64 = v1749 + @as(i64, 1);
    const v1751: i64 = v1750 + @as(i64, 1);
    const v1752: i64 = @as(i64, 0) + @as(i64, 1);
    const v1753: i64 = v1752 + @as(i64, 1);
    const v1754: i64 = v1753 + @as(i64, 1);
    const v1755: i64 = v1754 + @as(i64, 1);
    const v1756: i64 = v1755 + @as(i64, 1);
    const v1757: bool = v1751 == v1756;
    if (v1757) {
        v1758 = @as(i64, 0);
    } else {
        v1758 = @as(i64, 1);
    }
    const v1761: i64 = v1746 +% v1758;
    const v1764: i64 = v1742 +% v1761;
    const v1765: i64 = @as(i64, 0) + @as(i64, 1);
    const v1766: i64 = v1765 + @as(i64, 1);
    const v1767: i64 = v1766 + @as(i64, 1);
    const v1768: i64 = v1767 + @as(i64, 1);
    const v1769: i64 = @as(i64, 0) + @as(i64, 1);
    const v1770: i64 = v1769 + @as(i64, 1);
    const v1771: i64 = v1770 + @as(i64, 1);
    const v1772: i64 = v1771 + @as(i64, 1);
    const v1773: bool = v1768 == v1772;
    if (v1773) {
        v1774 = @as(i64, 0);
    } else {
        v1774 = @as(i64, 1);
    }
    const v1775: i64 = @as(i64, 0) + @as(i64, 1);
    const v1776: i64 = @as(i64, 0) + @as(i64, 1);
    const v1777: bool = v1775 == v1776;
    if (v1777) {
        v1778 = @as(i64, 0);
    } else {
        v1778 = @as(i64, 1);
    }
    const v1779: i64 = @as(i64, 0) + @as(i64, 1);
    const v1780: i64 = v1779 + @as(i64, 1);
    const v1781: i64 = v1780 + @as(i64, 1);
    const v1782: i64 = v1781 + @as(i64, 1);
    const v1783: i64 = v1782 + @as(i64, 1);
    const v1784: i64 = @as(i64, 0) + @as(i64, 1);
    const v1785: i64 = v1784 + @as(i64, 1);
    const v1786: i64 = v1785 + @as(i64, 1);
    const v1787: i64 = v1786 + @as(i64, 1);
    const v1788: i64 = v1787 + @as(i64, 1);
    const v1789: bool = v1783 == v1788;
    if (v1789) {
        v1790 = @as(i64, 0);
    } else {
        v1790 = @as(i64, 1);
    }
    const v1793: i64 = v1778 +% v1790;
    const v1796: i64 = v1774 +% v1793;
    const v1797: i64 = @as(i64, 0) + @as(i64, 1);
    const v1798: i64 = v1797 + @as(i64, 1);
    const v1799: i64 = v1798 + @as(i64, 1);
    const v1800: i64 = v1799 + @as(i64, 1);
    const v1801: i64 = @as(i64, 0) + @as(i64, 1);
    const v1802: i64 = v1801 + @as(i64, 1);
    const v1803: i64 = v1802 + @as(i64, 1);
    const v1804: i64 = v1803 + @as(i64, 1);
    const v1805: bool = v1800 == v1804;
    if (v1805) {
        v1806 = @as(i64, 0);
    } else {
        v1806 = @as(i64, 1);
    }
    const v1807: i64 = @as(i64, 0) + @as(i64, 1);
    const v1808: i64 = @as(i64, 0) + @as(i64, 1);
    const v1809: bool = v1807 == v1808;
    if (v1809) {
        v1810 = @as(i64, 0);
    } else {
        v1810 = @as(i64, 1);
    }
    const v1811: i64 = @as(i64, 0) + @as(i64, 1);
    const v1812: i64 = v1811 + @as(i64, 1);
    const v1813: i64 = v1812 + @as(i64, 1);
    const v1814: i64 = v1813 + @as(i64, 1);
    const v1815: i64 = v1814 + @as(i64, 1);
    const v1816: i64 = @as(i64, 0) + @as(i64, 1);
    const v1817: i64 = v1816 + @as(i64, 1);
    const v1818: i64 = v1817 + @as(i64, 1);
    const v1819: i64 = v1818 + @as(i64, 1);
    const v1820: i64 = v1819 + @as(i64, 1);
    const v1821: bool = v1815 == v1820;
    if (v1821) {
        v1822 = @as(i64, 0);
    } else {
        v1822 = @as(i64, 1);
    }
    const v1825: i64 = v1810 +% v1822;
    const v1828: i64 = v1806 +% v1825;
    const v1829: i64 = @as(i64, 0) + @as(i64, 1);
    const v1830: i64 = v1829 + @as(i64, 1);
    const v1831: i64 = v1830 + @as(i64, 1);
    const v1832: i64 = v1831 + @as(i64, 1);
    const v1833: i64 = @as(i64, 0) + @as(i64, 1);
    const v1834: i64 = v1833 + @as(i64, 1);
    const v1835: i64 = v1834 + @as(i64, 1);
    const v1836: i64 = v1835 + @as(i64, 1);
    const v1837: bool = v1832 == v1836;
    if (v1837) {
        v1838 = @as(i64, 0);
    } else {
        v1838 = @as(i64, 1);
    }
    const v1839: i64 = @as(i64, 0) + @as(i64, 1);
    const v1840: i64 = @as(i64, 0) + @as(i64, 1);
    const v1841: bool = v1839 == v1840;
    if (v1841) {
        v1842 = @as(i64, 0);
    } else {
        v1842 = @as(i64, 1);
    }
    const v1843: i64 = @as(i64, 0) + @as(i64, 1);
    const v1844: i64 = v1843 + @as(i64, 1);
    const v1845: i64 = v1844 + @as(i64, 1);
    const v1846: i64 = v1845 + @as(i64, 1);
    const v1847: i64 = v1846 + @as(i64, 1);
    const v1848: i64 = @as(i64, 0) + @as(i64, 1);
    const v1849: i64 = v1848 + @as(i64, 1);
    const v1850: i64 = v1849 + @as(i64, 1);
    const v1851: i64 = v1850 + @as(i64, 1);
    const v1852: i64 = v1851 + @as(i64, 1);
    const v1853: bool = v1847 == v1852;
    if (v1853) {
        v1854 = @as(i64, 0);
    } else {
        v1854 = @as(i64, 1);
    }
    const v1857: i64 = v1842 +% v1854;
    const v1860: i64 = v1838 +% v1857;
    const v1861: i64 = v1828 +% v1860;
    const v1862: i64 = v1796 +% v1861;
    const v1863: i64 = v1764 +% v1862;
    const v1864: i64 = v1732 +% v1863;
    const v1865: i64 = @as(i64, 0) + @as(i64, 1);
    const v1866: i64 = v1865 + @as(i64, 1);
    const v1867: i64 = v1866 + @as(i64, 1);
    const v1868: i64 = v1867 + @as(i64, 1);
    const v1869: i64 = @as(i64, 0) + @as(i64, 1);
    const v1870: i64 = v1869 + @as(i64, 1);
    const v1871: i64 = v1870 + @as(i64, 1);
    const v1872: i64 = v1871 + @as(i64, 1);
    const v1873: bool = v1868 == v1872;
    if (v1873) {
        v1874 = @as(i64, 0);
    } else {
        v1874 = @as(i64, 1);
    }
    const v1875: i64 = @as(i64, 0) + @as(i64, 1);
    const v1876: i64 = @as(i64, 0) + @as(i64, 1);
    const v1877: bool = v1875 == v1876;
    if (v1877) {
        v1878 = @as(i64, 0);
    } else {
        v1878 = @as(i64, 1);
    }
    const v1879: i64 = @as(i64, 0) + @as(i64, 1);
    const v1880: i64 = v1879 + @as(i64, 1);
    const v1881: i64 = v1880 + @as(i64, 1);
    const v1882: i64 = v1881 + @as(i64, 1);
    const v1883: i64 = v1882 + @as(i64, 1);
    const v1884: i64 = @as(i64, 0) + @as(i64, 1);
    const v1885: i64 = v1884 + @as(i64, 1);
    const v1886: i64 = v1885 + @as(i64, 1);
    const v1887: i64 = v1886 + @as(i64, 1);
    const v1888: i64 = v1887 + @as(i64, 1);
    const v1889: bool = v1883 == v1888;
    if (v1889) {
        v1890 = @as(i64, 0);
    } else {
        v1890 = @as(i64, 1);
    }
    const v1891: i64 = v1875 +% v1883;
    const v1892: i64 = v1876 +% v1888;
    const v1893: i64 = v1878 +% v1890;
    const v1894: i64 = v1868 +% v1891;
    const v1895: i64 = v1872 +% v1892;
    const v1896: i64 = v1874 +% v1893;
    const v1897: i64 = v1895 +% v1896;
    const v1898: i64 = v1894 +% v1897;
    const v1899: i64 = @as(i64, 3) +% v1898;
    const v1900: i64 = @as(i64, 0) + @as(i64, 1);
    const v1901: i64 = v1900 + @as(i64, 1);
    const v1902: i64 = v1901 + @as(i64, 1);
    const v1903: i64 = v1902 + @as(i64, 1);
    const v1904: i64 = @as(i64, 0) + @as(i64, 1);
    const v1905: i64 = v1904 + @as(i64, 1);
    const v1906: i64 = v1905 + @as(i64, 1);
    const v1907: i64 = v1906 + @as(i64, 1);
    const v1908: bool = v1903 == v1907;
    if (v1908) {
        v1909 = @as(i64, 0);
    } else {
        v1909 = @as(i64, 1);
    }
    const v1910: i64 = @as(i64, 0) + @as(i64, 1);
    const v1911: i64 = @as(i64, 0) + @as(i64, 1);
    const v1912: bool = v1910 == v1911;
    if (v1912) {
        v1913 = @as(i64, 0);
    } else {
        v1913 = @as(i64, 1);
    }
    const v1914: i64 = @as(i64, 0) + @as(i64, 1);
    const v1915: i64 = v1914 + @as(i64, 1);
    const v1916: i64 = v1915 + @as(i64, 1);
    const v1917: i64 = v1916 + @as(i64, 1);
    const v1918: i64 = v1917 + @as(i64, 1);
    const v1919: i64 = @as(i64, 0) + @as(i64, 1);
    const v1920: i64 = v1919 + @as(i64, 1);
    const v1921: i64 = v1920 + @as(i64, 1);
    const v1922: i64 = v1921 + @as(i64, 1);
    const v1923: i64 = v1922 + @as(i64, 1);
    const v1924: bool = v1918 == v1923;
    if (v1924) {
        v1925 = @as(i64, 0);
    } else {
        v1925 = @as(i64, 1);
    }
    const v1926: i64 = v1910 +% v1918;
    const v1927: i64 = v1911 +% v1923;
    const v1928: i64 = v1913 +% v1925;
    const v1929: i64 = v1903 +% v1926;
    const v1930: i64 = v1907 +% v1927;
    const v1931: i64 = v1909 +% v1928;
    const v1932: i64 = v1930 +% v1931;
    const v1933: i64 = v1929 +% v1932;
    const v1934: i64 = @as(i64, 3) +% v1933;
    const v1935: bool = v1899 == v1934;
    if (v1935) {
        v1936 = @as(i64, 0) + @as(i64, 1);
        v1937 = v1936 + @as(i64, 1);
        v1938 = v1937 + @as(i64, 1);
        v1939 = v1938 + @as(i64, 1);
        v1940 = @as(i64, 0) + @as(i64, 1);
        v1941 = v1940 + @as(i64, 1);
        v1942 = v1941 + @as(i64, 1);
        v1943 = v1942 + @as(i64, 1);
        v1944 = v1939 == v1943;
        if (v1944) {
            v1945 = @as(i64, 0);
        } else {
            v1945 = @as(i64, 1);
        }
        v1946 = @as(i64, 0) + @as(i64, 1);
        v1947 = @as(i64, 0) + @as(i64, 1);
        v1948 = v1946 == v1947;
        if (v1948) {
            v1949 = @as(i64, 0);
        } else {
            v1949 = @as(i64, 1);
        }
        v1950 = @as(i64, 0) + @as(i64, 1);
        v1951 = v1950 + @as(i64, 1);
        v1952 = v1951 + @as(i64, 1);
        v1953 = v1952 + @as(i64, 1);
        v1954 = v1953 + @as(i64, 1);
        v1955 = @as(i64, 0) + @as(i64, 1);
        v1956 = v1955 + @as(i64, 1);
        v1957 = v1956 + @as(i64, 1);
        v1958 = v1957 + @as(i64, 1);
        v1959 = v1958 + @as(i64, 1);
        v1960 = v1954 == v1959;
        if (v1960) {
            v1961 = @as(i64, 0);
        } else {
            v1961 = @as(i64, 1);
        }
        v1962 = v1946 +% v1954;
        v1963 = v1947 +% v1959;
        v1964 = v1949 +% v1961;
        v1965 = v1939 +% v1962;
        v1966 = v1943 +% v1963;
        v1967 = v1945 +% v1964;
        v1968 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation";
        v1972 = US0_TypedFxHashedStatementChecksumValidationAccepted(@as(i64, 1), @as(i64, 3), v1965, v1966, v1967, v1968);
    } else {
        v1970 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric";
        v1972 = US0_TypedFxHashedStatementChecksumValidationRejected(v1899, v1934, v1970);
    }
    switch (v1972.tag) {
        0 => {
            v1976 = v1972.c0_0;
            v1977 = v1972.c0_1;
            v1978 = v1972.c0_2;
            v1979 = v1972.c0_3;
            v1980 = v1972.c0_4;
            v1981 = v1972.c0_5;
            v1991 = @as(i64, 1);
            v1992 = @as(i64, 0);
            v1995 = v1976;
            v1999 = v1980;
        },
        1 => {
            v1973 = v1972.c1_0;
            v1974 = v1972.c1_1;
            v1975 = v1972.c1_2;
            v1991 = @as(i64, 0);
            v1992 = @as(i64, 1);
            v1995 = @as(i64, 0);
            v1999 = @as(i64, 0);
        },
        else => unreachable,
    }
    const v2000: i64 = @as(i64, 0) + @as(i64, 1);
    const v2001: i64 = v2000 + @as(i64, 1);
    const v2002: i64 = v2001 + @as(i64, 1);
    const v2003: i64 = v2002 + @as(i64, 1);
    const v2004: i64 = @as(i64, 0) + @as(i64, 1);
    const v2005: i64 = v2004 + @as(i64, 1);
    const v2006: i64 = v2005 + @as(i64, 1);
    const v2007: i64 = v2006 + @as(i64, 1);
    const v2008: bool = v2003 == v2007;
    if (v2008) {
        v2009 = @as(i64, 0);
    } else {
        v2009 = @as(i64, 1);
    }
    const v2010: i64 = @as(i64, 0) + @as(i64, 1);
    const v2011: i64 = @as(i64, 0) + @as(i64, 1);
    const v2012: bool = v2010 == v2011;
    if (v2012) {
        v2013 = @as(i64, 0);
    } else {
        v2013 = @as(i64, 1);
    }
    const v2014: i64 = @as(i64, 0) + @as(i64, 1);
    const v2015: i64 = v2014 + @as(i64, 1);
    const v2016: i64 = v2015 + @as(i64, 1);
    const v2017: i64 = v2016 + @as(i64, 1);
    const v2018: i64 = v2017 + @as(i64, 1);
    const v2019: i64 = @as(i64, 0) + @as(i64, 1);
    const v2020: i64 = v2019 + @as(i64, 1);
    const v2021: i64 = v2020 + @as(i64, 1);
    const v2022: i64 = v2021 + @as(i64, 1);
    const v2023: i64 = v2022 + @as(i64, 1);
    const v2024: bool = v2018 == v2023;
    if (v2024) {
        v2025 = @as(i64, 0);
    } else {
        v2025 = @as(i64, 1);
    }
    const v2028: i64 = v2013 +% v2025;
    const v2031: i64 = v2009 +% v2028;
    const v2032: i64 = @as(i64, 0) + @as(i64, 1);
    const v2033: i64 = v2032 + @as(i64, 1);
    const v2034: i64 = v2033 + @as(i64, 1);
    const v2035: i64 = v2034 + @as(i64, 1);
    const v2036: i64 = @as(i64, 0) + @as(i64, 1);
    const v2037: i64 = v2036 + @as(i64, 1);
    const v2038: i64 = v2037 + @as(i64, 1);
    const v2039: i64 = v2038 + @as(i64, 1);
    const v2040: bool = v2035 == v2039;
    if (v2040) {
        v2041 = @as(i64, 0);
    } else {
        v2041 = @as(i64, 1);
    }
    const v2042: i64 = @as(i64, 0) + @as(i64, 1);
    const v2043: i64 = @as(i64, 0) + @as(i64, 1);
    const v2044: bool = v2042 == v2043;
    if (v2044) {
        v2045 = @as(i64, 0);
    } else {
        v2045 = @as(i64, 1);
    }
    const v2046: i64 = @as(i64, 0) + @as(i64, 1);
    const v2047: i64 = v2046 + @as(i64, 1);
    const v2048: i64 = v2047 + @as(i64, 1);
    const v2049: i64 = v2048 + @as(i64, 1);
    const v2050: i64 = v2049 + @as(i64, 1);
    const v2051: i64 = @as(i64, 0) + @as(i64, 1);
    const v2052: i64 = v2051 + @as(i64, 1);
    const v2053: i64 = v2052 + @as(i64, 1);
    const v2054: i64 = v2053 + @as(i64, 1);
    const v2055: i64 = v2054 + @as(i64, 1);
    const v2056: bool = v2050 == v2055;
    if (v2056) {
        v2057 = @as(i64, 0);
    } else {
        v2057 = @as(i64, 1);
    }
    const v2060: i64 = v2045 +% v2057;
    const v2063: i64 = v2041 +% v2060;
    const v2064: i64 = @as(i64, 0) + @as(i64, 1);
    const v2065: i64 = v2064 + @as(i64, 1);
    const v2066: i64 = v2065 + @as(i64, 1);
    const v2067: i64 = v2066 + @as(i64, 1);
    const v2068: i64 = @as(i64, 0) + @as(i64, 1);
    const v2069: i64 = v2068 + @as(i64, 1);
    const v2070: i64 = v2069 + @as(i64, 1);
    const v2071: i64 = v2070 + @as(i64, 1);
    const v2072: bool = v2067 == v2071;
    if (v2072) {
        v2073 = @as(i64, 0);
    } else {
        v2073 = @as(i64, 1);
    }
    const v2074: i64 = @as(i64, 0) + @as(i64, 1);
    const v2075: i64 = @as(i64, 0) + @as(i64, 1);
    const v2076: bool = v2074 == v2075;
    if (v2076) {
        v2077 = @as(i64, 0);
    } else {
        v2077 = @as(i64, 1);
    }
    const v2078: i64 = @as(i64, 0) + @as(i64, 1);
    const v2079: i64 = v2078 + @as(i64, 1);
    const v2080: i64 = v2079 + @as(i64, 1);
    const v2081: i64 = v2080 + @as(i64, 1);
    const v2082: i64 = v2081 + @as(i64, 1);
    const v2083: i64 = @as(i64, 0) + @as(i64, 1);
    const v2084: i64 = v2083 + @as(i64, 1);
    const v2085: i64 = v2084 + @as(i64, 1);
    const v2086: i64 = v2085 + @as(i64, 1);
    const v2087: i64 = v2086 + @as(i64, 1);
    const v2088: bool = v2082 == v2087;
    if (v2088) {
        v2089 = @as(i64, 0);
    } else {
        v2089 = @as(i64, 1);
    }
    const v2092: i64 = v2077 +% v2089;
    const v2095: i64 = v2073 +% v2092;
    const v2096: i64 = @as(i64, 0) + @as(i64, 1);
    const v2097: i64 = v2096 + @as(i64, 1);
    const v2098: i64 = v2097 + @as(i64, 1);
    const v2099: i64 = v2098 + @as(i64, 1);
    const v2100: i64 = @as(i64, 0) + @as(i64, 1);
    const v2101: i64 = v2100 + @as(i64, 1);
    const v2102: i64 = v2101 + @as(i64, 1);
    const v2103: i64 = v2102 + @as(i64, 1);
    const v2104: bool = v2099 == v2103;
    if (v2104) {
        v2105 = @as(i64, 0);
    } else {
        v2105 = @as(i64, 1);
    }
    const v2106: i64 = @as(i64, 0) + @as(i64, 1);
    const v2107: i64 = @as(i64, 0) + @as(i64, 1);
    const v2108: bool = v2106 == v2107;
    if (v2108) {
        v2109 = @as(i64, 0);
    } else {
        v2109 = @as(i64, 1);
    }
    const v2110: i64 = @as(i64, 0) + @as(i64, 1);
    const v2111: i64 = v2110 + @as(i64, 1);
    const v2112: i64 = v2111 + @as(i64, 1);
    const v2113: i64 = v2112 + @as(i64, 1);
    const v2114: i64 = v2113 + @as(i64, 1);
    const v2115: i64 = @as(i64, 0) + @as(i64, 1);
    const v2116: i64 = v2115 + @as(i64, 1);
    const v2117: i64 = v2116 + @as(i64, 1);
    const v2118: i64 = v2117 + @as(i64, 1);
    const v2119: i64 = v2118 + @as(i64, 1);
    const v2120: bool = v2114 == v2119;
    if (v2120) {
        v2121 = @as(i64, 0);
    } else {
        v2121 = @as(i64, 1);
    }
    const v2124: i64 = v2109 +% v2121;
    const v2127: i64 = v2105 +% v2124;
    const v2128: i64 = v2095 +% v2127;
    const v2129: i64 = v2063 +% v2128;
    const v2130: i64 = v2031 +% v2129;
    const v2131: i64 = v1999 +% v1992;
    const v2132: i64 = v2130 +% v2131;
    const v2133: i64 = v1864 +% v2132;
    const v2134: bool = v1995 == @as(i64, 1);
    const v2135: bool = v1991 == @as(i64, 1);
    const v2136: bool = v2133 == @as(i64, 0);
    const v2137: bool = (v2134 and v2135);
    const v2138: bool = (v2137 and v2136);
    if (v2138) {
    } else {
        if (spiral_true) spiralFail("typed-FX-statement-recursive-writer-appended-tail-restart-runtime-mismatch");
    }
    const v2139: i64 = @as(i64, 0) + @as(i64, 1);
    const v2140: i64 = v2139 + @as(i64, 1);
    const v2141: i64 = v2140 + @as(i64, 1);
    const v2142: i64 = v2141 + @as(i64, 1);
    const v2143: i64 = @as(i64, 0) + @as(i64, 1);
    const v2144: i64 = v2143 + @as(i64, 1);
    const v2145: i64 = v2144 + @as(i64, 1);
    const v2146: i64 = v2145 + @as(i64, 1);
    const v2147: bool = v2142 == v2146;
    if (v2147) {
        v2148 = @as(i64, 0);
    } else {
        v2148 = @as(i64, 1);
    }
    const v2149: i64 = @as(i64, 0) + @as(i64, 1);
    const v2150: i64 = @as(i64, 0) + @as(i64, 1);
    const v2151: bool = v2149 == v2150;
    if (v2151) {
        v2152 = @as(i64, 0);
    } else {
        v2152 = @as(i64, 1);
    }
    const v2153: i64 = @as(i64, 0) + @as(i64, 1);
    const v2154: i64 = v2153 + @as(i64, 1);
    const v2155: i64 = v2154 + @as(i64, 1);
    const v2156: i64 = v2155 + @as(i64, 1);
    const v2157: i64 = v2156 + @as(i64, 1);
    const v2158: i64 = @as(i64, 0) + @as(i64, 1);
    const v2159: i64 = v2158 + @as(i64, 1);
    const v2160: i64 = v2159 + @as(i64, 1);
    const v2161: i64 = v2160 + @as(i64, 1);
    const v2162: i64 = v2161 + @as(i64, 1);
    const v2163: bool = v2157 == v2162;
    if (v2163) {
        v2164 = @as(i64, 0);
    } else {
        v2164 = @as(i64, 1);
    }
    const v2167: i64 = v2152 +% v2164;
    const v2170: i64 = v2148 +% v2167;
    const v2171: i64 = @as(i64, 0) + @as(i64, 1);
    const v2172: i64 = v2171 + @as(i64, 1);
    const v2173: i64 = v2172 + @as(i64, 1);
    const v2174: i64 = v2173 + @as(i64, 1);
    const v2175: i64 = @as(i64, 0) + @as(i64, 1);
    const v2176: i64 = v2175 + @as(i64, 1);
    const v2177: i64 = v2176 + @as(i64, 1);
    const v2178: i64 = v2177 + @as(i64, 1);
    const v2179: bool = v2174 == v2178;
    if (v2179) {
        v2180 = @as(i64, 0);
    } else {
        v2180 = @as(i64, 1);
    }
    const v2181: i64 = @as(i64, 0) + @as(i64, 1);
    const v2182: i64 = @as(i64, 0) + @as(i64, 1);
    const v2183: bool = v2181 == v2182;
    if (v2183) {
        v2184 = @as(i64, 0);
    } else {
        v2184 = @as(i64, 1);
    }
    const v2185: i64 = @as(i64, 0) + @as(i64, 1);
    const v2186: i64 = v2185 + @as(i64, 1);
    const v2187: i64 = v2186 + @as(i64, 1);
    const v2188: i64 = v2187 + @as(i64, 1);
    const v2189: i64 = v2188 + @as(i64, 1);
    const v2190: i64 = @as(i64, 0) + @as(i64, 1);
    const v2191: i64 = v2190 + @as(i64, 1);
    const v2192: i64 = v2191 + @as(i64, 1);
    const v2193: i64 = v2192 + @as(i64, 1);
    const v2194: i64 = v2193 + @as(i64, 1);
    const v2195: bool = v2189 == v2194;
    if (v2195) {
        v2196 = @as(i64, 0);
    } else {
        v2196 = @as(i64, 1);
    }
    const v2199: i64 = v2184 +% v2196;
    const v2202: i64 = v2180 +% v2199;
    const v2203: i64 = v2170 +% v2202;
    const v2204: i64 = @as(i64, 0) + @as(i64, 1);
    const v2205: i64 = v2204 + @as(i64, 1);
    const v2206: i64 = v2205 + @as(i64, 1);
    const v2207: i64 = v2206 + @as(i64, 1);
    const v2208: i64 = @as(i64, 0) + @as(i64, 1);
    const v2209: i64 = v2208 + @as(i64, 1);
    const v2210: i64 = v2209 + @as(i64, 1);
    const v2211: i64 = v2210 + @as(i64, 1);
    const v2212: bool = v2207 == v2211;
    if (v2212) {
        v2213 = @as(i64, 0);
    } else {
        v2213 = @as(i64, 1);
    }
    const v2214: i64 = @as(i64, 0) + @as(i64, 1);
    const v2215: i64 = @as(i64, 0) + @as(i64, 1);
    const v2216: bool = v2214 == v2215;
    if (v2216) {
        v2217 = @as(i64, 0);
    } else {
        v2217 = @as(i64, 1);
    }
    const v2218: i64 = @as(i64, 0) + @as(i64, 1);
    const v2219: i64 = v2218 + @as(i64, 1);
    const v2220: i64 = v2219 + @as(i64, 1);
    const v2221: i64 = v2220 + @as(i64, 1);
    const v2222: i64 = v2221 + @as(i64, 1);
    const v2223: i64 = @as(i64, 0) + @as(i64, 1);
    const v2224: i64 = v2223 + @as(i64, 1);
    const v2225: i64 = v2224 + @as(i64, 1);
    const v2226: i64 = v2225 + @as(i64, 1);
    const v2227: i64 = v2226 + @as(i64, 1);
    const v2228: bool = v2222 == v2227;
    if (v2228) {
        v2229 = @as(i64, 0);
    } else {
        v2229 = @as(i64, 1);
    }
    const v2232: i64 = v2217 +% v2229;
    const v2235: i64 = v2213 +% v2232;
    const v2236: i64 = @as(i64, 0) + @as(i64, 1);
    const v2237: i64 = v2236 + @as(i64, 1);
    const v2238: i64 = v2237 + @as(i64, 1);
    const v2239: i64 = v2238 + @as(i64, 1);
    const v2240: i64 = @as(i64, 0) + @as(i64, 1);
    const v2241: i64 = v2240 + @as(i64, 1);
    const v2242: i64 = v2241 + @as(i64, 1);
    const v2243: i64 = v2242 + @as(i64, 1);
    const v2244: bool = v2239 == v2243;
    if (v2244) {
        v2245 = @as(i64, 0);
    } else {
        v2245 = @as(i64, 1);
    }
    const v2246: i64 = @as(i64, 0) + @as(i64, 1);
    const v2247: i64 = @as(i64, 0) + @as(i64, 1);
    const v2248: bool = v2246 == v2247;
    if (v2248) {
        v2249 = @as(i64, 0);
    } else {
        v2249 = @as(i64, 1);
    }
    const v2250: i64 = @as(i64, 0) + @as(i64, 1);
    const v2251: i64 = v2250 + @as(i64, 1);
    const v2252: i64 = v2251 + @as(i64, 1);
    const v2253: i64 = v2252 + @as(i64, 1);
    const v2254: i64 = v2253 + @as(i64, 1);
    const v2255: i64 = @as(i64, 0) + @as(i64, 1);
    const v2256: i64 = v2255 + @as(i64, 1);
    const v2257: i64 = v2256 + @as(i64, 1);
    const v2258: i64 = v2257 + @as(i64, 1);
    const v2259: i64 = v2258 + @as(i64, 1);
    const v2260: bool = v2254 == v2259;
    if (v2260) {
        v2261 = @as(i64, 0);
    } else {
        v2261 = @as(i64, 1);
    }
    const v2264: i64 = v2249 +% v2261;
    const v2267: i64 = v2245 +% v2264;
    const v2268: i64 = v2235 +% v2267;
    const v2269: i64 = v2203 +% v2268;
    const v2270: i64 = @as(i64, 0) + @as(i64, 1);
    const v2271: i64 = v2270 + @as(i64, 1);
    const v2272: i64 = v2271 + @as(i64, 1);
    const v2273: i64 = v2272 + @as(i64, 1);
    const v2274: i64 = @as(i64, 0) + @as(i64, 1);
    const v2275: i64 = v2274 + @as(i64, 1);
    const v2276: i64 = v2275 + @as(i64, 1);
    const v2277: i64 = v2276 + @as(i64, 1);
    const v2278: bool = v2273 == v2277;
    if (v2278) {
        v2279 = @as(i64, 0);
    } else {
        v2279 = @as(i64, 1);
    }
    const v2280: i64 = @as(i64, 0) + @as(i64, 1);
    const v2281: i64 = @as(i64, 0) + @as(i64, 1);
    const v2282: bool = v2280 == v2281;
    if (v2282) {
        v2283 = @as(i64, 0);
    } else {
        v2283 = @as(i64, 1);
    }
    const v2284: i64 = @as(i64, 0) + @as(i64, 1);
    const v2285: i64 = v2284 + @as(i64, 1);
    const v2286: i64 = v2285 + @as(i64, 1);
    const v2287: i64 = v2286 + @as(i64, 1);
    const v2288: i64 = v2287 + @as(i64, 1);
    const v2289: i64 = @as(i64, 0) + @as(i64, 1);
    const v2290: i64 = v2289 + @as(i64, 1);
    const v2291: i64 = v2290 + @as(i64, 1);
    const v2292: i64 = v2291 + @as(i64, 1);
    const v2293: i64 = v2292 + @as(i64, 1);
    const v2294: bool = v2288 == v2293;
    if (v2294) {
        v2295 = @as(i64, 0);
    } else {
        v2295 = @as(i64, 1);
    }
    const v2296: i64 = v2280 +% v2288;
    const v2297: i64 = v2281 +% v2293;
    const v2298: i64 = v2283 +% v2295;
    const v2299: i64 = v2273 +% v2296;
    const v2300: i64 = v2277 +% v2297;
    const v2301: i64 = v2279 +% v2298;
    const v2302: i64 = v2300 +% v2301;
    const v2303: i64 = v2299 +% v2302;
    const v2304: i64 = @as(i64, 3) +% v2303;
    const v2305: i64 = @as(i64, 0) + @as(i64, 1);
    const v2306: i64 = v2305 + @as(i64, 1);
    const v2307: i64 = v2306 + @as(i64, 1);
    const v2308: i64 = v2307 + @as(i64, 1);
    const v2309: i64 = @as(i64, 0) + @as(i64, 1);
    const v2310: i64 = v2309 + @as(i64, 1);
    const v2311: i64 = v2310 + @as(i64, 1);
    const v2312: i64 = v2311 + @as(i64, 1);
    const v2313: bool = v2308 == v2312;
    if (v2313) {
        v2314 = @as(i64, 0);
    } else {
        v2314 = @as(i64, 1);
    }
    const v2315: i64 = @as(i64, 0) + @as(i64, 1);
    const v2316: i64 = @as(i64, 0) + @as(i64, 1);
    const v2317: bool = v2315 == v2316;
    if (v2317) {
        v2318 = @as(i64, 0);
    } else {
        v2318 = @as(i64, 1);
    }
    const v2319: i64 = @as(i64, 0) + @as(i64, 1);
    const v2320: i64 = v2319 + @as(i64, 1);
    const v2321: i64 = v2320 + @as(i64, 1);
    const v2322: i64 = v2321 + @as(i64, 1);
    const v2323: i64 = v2322 + @as(i64, 1);
    const v2324: i64 = @as(i64, 0) + @as(i64, 1);
    const v2325: i64 = v2324 + @as(i64, 1);
    const v2326: i64 = v2325 + @as(i64, 1);
    const v2327: i64 = v2326 + @as(i64, 1);
    const v2328: i64 = v2327 + @as(i64, 1);
    const v2329: bool = v2323 == v2328;
    if (v2329) {
        v2330 = @as(i64, 0);
    } else {
        v2330 = @as(i64, 1);
    }
    const v2331: i64 = v2315 +% v2323;
    const v2332: i64 = v2316 +% v2328;
    const v2333: i64 = v2318 +% v2330;
    const v2334: i64 = v2308 +% v2331;
    const v2335: i64 = v2312 +% v2332;
    const v2336: i64 = v2314 +% v2333;
    const v2337: i64 = v2335 +% v2336;
    const v2338: i64 = v2334 +% v2337;
    const v2339: i64 = @as(i64, 3) +% v2338;
    const v2340: bool = v2304 == v2339;
    if (v2340) {
        v2341 = @as(i64, 0) + @as(i64, 1);
        v2342 = v2341 + @as(i64, 1);
        v2343 = v2342 + @as(i64, 1);
        v2344 = v2343 + @as(i64, 1);
        v2345 = @as(i64, 0) + @as(i64, 1);
        v2346 = v2345 + @as(i64, 1);
        v2347 = v2346 + @as(i64, 1);
        v2348 = v2347 + @as(i64, 1);
        v2349 = v2344 == v2348;
        if (v2349) {
            v2350 = @as(i64, 0);
        } else {
            v2350 = @as(i64, 1);
        }
        v2351 = @as(i64, 0) + @as(i64, 1);
        v2352 = @as(i64, 0) + @as(i64, 1);
        v2353 = v2351 == v2352;
        if (v2353) {
            v2354 = @as(i64, 0);
        } else {
            v2354 = @as(i64, 1);
        }
        v2355 = @as(i64, 0) + @as(i64, 1);
        v2356 = v2355 + @as(i64, 1);
        v2357 = v2356 + @as(i64, 1);
        v2358 = v2357 + @as(i64, 1);
        v2359 = v2358 + @as(i64, 1);
        v2360 = @as(i64, 0) + @as(i64, 1);
        v2361 = v2360 + @as(i64, 1);
        v2362 = v2361 + @as(i64, 1);
        v2363 = v2362 + @as(i64, 1);
        v2364 = v2363 + @as(i64, 1);
        v2365 = v2359 == v2364;
        if (v2365) {
            v2366 = @as(i64, 0);
        } else {
            v2366 = @as(i64, 1);
        }
        v2367 = v2351 +% v2359;
        v2368 = v2352 +% v2364;
        v2369 = v2354 +% v2366;
        v2370 = v2344 +% v2367;
        v2371 = v2348 +% v2368;
        v2372 = v2350 +% v2369;
        v2373 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation";
        v2377 = US0_TypedFxHashedStatementChecksumValidationAccepted(@as(i64, 1), @as(i64, 3), v2370, v2371, v2372, v2373);
    } else {
        v2375 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric";
        v2377 = US0_TypedFxHashedStatementChecksumValidationRejected(v2304, v2339, v2375);
    }
    switch (v2377.tag) {
        0 => {
            v2381 = v2377.c0_0;
            v2382 = v2377.c0_1;
            v2383 = v2377.c0_2;
            v2384 = v2377.c0_3;
            v2385 = v2377.c0_4;
            v2386 = v2377.c0_5;
            v2396 = @as(i64, 1);
            v2397 = @as(i64, 0);
            v2404 = v2385;
        },
        1 => {
            v2378 = v2377.c1_0;
            v2379 = v2377.c1_1;
            v2380 = v2377.c1_2;
            v2396 = @as(i64, 0);
            v2397 = @as(i64, 1);
            v2404 = @as(i64, 0);
        },
        else => unreachable,
    }
    const v2405: i64 = @as(i64, 0) + @as(i64, 1);
    const v2406: i64 = v2405 + @as(i64, 1);
    const v2407: i64 = v2406 + @as(i64, 1);
    const v2408: i64 = v2407 + @as(i64, 1);
    const v2409: i64 = @as(i64, 0) + @as(i64, 1);
    const v2410: i64 = v2409 + @as(i64, 1);
    const v2411: i64 = v2410 + @as(i64, 1);
    const v2412: i64 = v2411 + @as(i64, 1);
    const v2413: bool = v2408 == v2412;
    if (v2413) {
        v2414 = @as(i64, 0);
    } else {
        v2414 = @as(i64, 1);
    }
    const v2415: i64 = @as(i64, 0) + @as(i64, 1);
    const v2416: i64 = @as(i64, 0) + @as(i64, 1);
    const v2417: bool = v2415 == v2416;
    if (v2417) {
        v2418 = @as(i64, 0);
    } else {
        v2418 = @as(i64, 1);
    }
    const v2419: i64 = @as(i64, 0) + @as(i64, 1);
    const v2420: i64 = v2419 + @as(i64, 1);
    const v2421: i64 = v2420 + @as(i64, 1);
    const v2422: i64 = v2421 + @as(i64, 1);
    const v2423: i64 = v2422 + @as(i64, 1);
    const v2424: i64 = @as(i64, 0) + @as(i64, 1);
    const v2425: i64 = v2424 + @as(i64, 1);
    const v2426: i64 = v2425 + @as(i64, 1);
    const v2427: i64 = v2426 + @as(i64, 1);
    const v2428: i64 = v2427 + @as(i64, 1);
    const v2429: bool = v2423 == v2428;
    if (v2429) {
        v2430 = @as(i64, 0);
    } else {
        v2430 = @as(i64, 1);
    }
    const v2433: i64 = v2418 +% v2430;
    const v2436: i64 = v2414 +% v2433;
    const v2437: i64 = @as(i64, 0) + @as(i64, 1);
    const v2438: i64 = v2437 + @as(i64, 1);
    const v2439: i64 = v2438 + @as(i64, 1);
    const v2440: i64 = v2439 + @as(i64, 1);
    const v2441: i64 = @as(i64, 0) + @as(i64, 1);
    const v2442: i64 = v2441 + @as(i64, 1);
    const v2443: i64 = v2442 + @as(i64, 1);
    const v2444: i64 = v2443 + @as(i64, 1);
    const v2445: bool = v2440 == v2444;
    if (v2445) {
        v2446 = @as(i64, 0);
    } else {
        v2446 = @as(i64, 1);
    }
    const v2447: i64 = @as(i64, 0) + @as(i64, 1);
    const v2448: i64 = @as(i64, 0) + @as(i64, 1);
    const v2449: bool = v2447 == v2448;
    if (v2449) {
        v2450 = @as(i64, 0);
    } else {
        v2450 = @as(i64, 1);
    }
    const v2451: i64 = @as(i64, 0) + @as(i64, 1);
    const v2452: i64 = v2451 + @as(i64, 1);
    const v2453: i64 = v2452 + @as(i64, 1);
    const v2454: i64 = v2453 + @as(i64, 1);
    const v2455: i64 = v2454 + @as(i64, 1);
    const v2456: i64 = @as(i64, 0) + @as(i64, 1);
    const v2457: i64 = v2456 + @as(i64, 1);
    const v2458: i64 = v2457 + @as(i64, 1);
    const v2459: i64 = v2458 + @as(i64, 1);
    const v2460: i64 = v2459 + @as(i64, 1);
    const v2461: bool = v2455 == v2460;
    if (v2461) {
        v2462 = @as(i64, 0);
    } else {
        v2462 = @as(i64, 1);
    }
    const v2465: i64 = v2450 +% v2462;
    const v2468: i64 = v2446 +% v2465;
    const v2469: i64 = v2436 +% v2468;
    const v2470: i64 = v2404 +% v2397;
    const v2471: i64 = v2469 +% v2470;
    const v2472: i64 = v2269 +% v2471;
    const v2473: bool = v2396 == @as(i64, 1);
    const v2474: bool = v2472 == @as(i64, 0);
    const v2475: bool = (v2473 and v2474);
    if (v2475) {
    } else {
        if (spiral_true) spiralFail("typed-FX-statement-recursive-writer-crash-phase-runtime-mismatch");
    }
    const v2476: i64 = @as(i64, 0) + @as(i64, 1);
    const v2477: i64 = v2476 + @as(i64, 1);
    const v2478: i64 = v2477 + @as(i64, 1);
    const v2479: i64 = v2478 + @as(i64, 1);
    const v2480: i64 = @as(i64, 0) + @as(i64, 1);
    const v2481: i64 = v2480 + @as(i64, 1);
    const v2482: i64 = v2481 + @as(i64, 1);
    const v2483: i64 = v2482 + @as(i64, 1);
    const v2484: bool = v2479 == v2483;
    if (v2484) {
        v2485 = @as(i64, 0);
    } else {
        v2485 = @as(i64, 1);
    }
    const v2486: i64 = @as(i64, 0) + @as(i64, 1);
    const v2487: i64 = @as(i64, 0) + @as(i64, 1);
    const v2488: bool = v2486 == v2487;
    if (v2488) {
        v2489 = @as(i64, 0);
    } else {
        v2489 = @as(i64, 1);
    }
    const v2490: i64 = @as(i64, 0) + @as(i64, 1);
    const v2491: i64 = v2490 + @as(i64, 1);
    const v2492: i64 = v2491 + @as(i64, 1);
    const v2493: i64 = v2492 + @as(i64, 1);
    const v2494: i64 = v2493 + @as(i64, 1);
    const v2495: i64 = @as(i64, 0) + @as(i64, 1);
    const v2496: i64 = v2495 + @as(i64, 1);
    const v2497: i64 = v2496 + @as(i64, 1);
    const v2498: i64 = v2497 + @as(i64, 1);
    const v2499: i64 = v2498 + @as(i64, 1);
    const v2500: bool = v2494 == v2499;
    if (v2500) {
        v2501 = @as(i64, 0);
    } else {
        v2501 = @as(i64, 1);
    }
    const v2504: i64 = v2489 +% v2501;
    const v2507: i64 = v2485 +% v2504;
    const v2508: i64 = @as(i64, 0) + @as(i64, 1);
    const v2509: i64 = v2508 + @as(i64, 1);
    const v2510: i64 = v2509 + @as(i64, 1);
    const v2511: i64 = v2510 + @as(i64, 1);
    const v2512: i64 = @as(i64, 0) + @as(i64, 1);
    const v2513: i64 = v2512 + @as(i64, 1);
    const v2514: i64 = v2513 + @as(i64, 1);
    const v2515: i64 = v2514 + @as(i64, 1);
    const v2516: bool = v2511 == v2515;
    if (v2516) {
        v2517 = @as(i64, 0);
    } else {
        v2517 = @as(i64, 1);
    }
    const v2518: i64 = @as(i64, 0) + @as(i64, 1);
    const v2519: i64 = @as(i64, 0) + @as(i64, 1);
    const v2520: bool = v2518 == v2519;
    if (v2520) {
        v2521 = @as(i64, 0);
    } else {
        v2521 = @as(i64, 1);
    }
    const v2522: i64 = @as(i64, 0) + @as(i64, 1);
    const v2523: i64 = v2522 + @as(i64, 1);
    const v2524: i64 = v2523 + @as(i64, 1);
    const v2525: i64 = v2524 + @as(i64, 1);
    const v2526: i64 = v2525 + @as(i64, 1);
    const v2527: i64 = @as(i64, 0) + @as(i64, 1);
    const v2528: i64 = v2527 + @as(i64, 1);
    const v2529: i64 = v2528 + @as(i64, 1);
    const v2530: i64 = v2529 + @as(i64, 1);
    const v2531: i64 = v2530 + @as(i64, 1);
    const v2532: bool = v2526 == v2531;
    if (v2532) {
        v2533 = @as(i64, 0);
    } else {
        v2533 = @as(i64, 1);
    }
    const v2536: i64 = v2521 +% v2533;
    const v2539: i64 = v2517 +% v2536;
    const v2540: i64 = v2507 +% v2539;
    const v2541: i64 = @as(i64, 0) + @as(i64, 1);
    const v2542: i64 = v2541 + @as(i64, 1);
    const v2543: i64 = v2542 + @as(i64, 1);
    const v2544: i64 = v2543 + @as(i64, 1);
    const v2545: i64 = @as(i64, 0) + @as(i64, 1);
    const v2546: i64 = v2545 + @as(i64, 1);
    const v2547: i64 = v2546 + @as(i64, 1);
    const v2548: i64 = v2547 + @as(i64, 1);
    const v2549: bool = v2544 == v2548;
    if (v2549) {
        v2550 = @as(i64, 0);
    } else {
        v2550 = @as(i64, 1);
    }
    const v2551: i64 = @as(i64, 0) + @as(i64, 1);
    const v2552: i64 = @as(i64, 0) + @as(i64, 1);
    const v2553: bool = v2551 == v2552;
    if (v2553) {
        v2554 = @as(i64, 0);
    } else {
        v2554 = @as(i64, 1);
    }
    const v2555: i64 = @as(i64, 0) + @as(i64, 1);
    const v2556: i64 = v2555 + @as(i64, 1);
    const v2557: i64 = v2556 + @as(i64, 1);
    const v2558: i64 = v2557 + @as(i64, 1);
    const v2559: i64 = v2558 + @as(i64, 1);
    const v2560: i64 = @as(i64, 0) + @as(i64, 1);
    const v2561: i64 = v2560 + @as(i64, 1);
    const v2562: i64 = v2561 + @as(i64, 1);
    const v2563: i64 = v2562 + @as(i64, 1);
    const v2564: i64 = v2563 + @as(i64, 1);
    const v2565: bool = v2559 == v2564;
    if (v2565) {
        v2566 = @as(i64, 0);
    } else {
        v2566 = @as(i64, 1);
    }
    const v2569: i64 = v2554 +% v2566;
    const v2572: i64 = v2550 +% v2569;
    const v2573: i64 = @as(i64, 0) + @as(i64, 1);
    const v2574: i64 = v2573 + @as(i64, 1);
    const v2575: i64 = v2574 + @as(i64, 1);
    const v2576: i64 = v2575 + @as(i64, 1);
    const v2577: i64 = @as(i64, 0) + @as(i64, 1);
    const v2578: i64 = v2577 + @as(i64, 1);
    const v2579: i64 = v2578 + @as(i64, 1);
    const v2580: i64 = v2579 + @as(i64, 1);
    const v2581: bool = v2576 == v2580;
    if (v2581) {
        v2582 = @as(i64, 0);
    } else {
        v2582 = @as(i64, 1);
    }
    const v2583: i64 = @as(i64, 0) + @as(i64, 1);
    const v2584: i64 = @as(i64, 0) + @as(i64, 1);
    const v2585: bool = v2583 == v2584;
    if (v2585) {
        v2586 = @as(i64, 0);
    } else {
        v2586 = @as(i64, 1);
    }
    const v2587: i64 = @as(i64, 0) + @as(i64, 1);
    const v2588: i64 = v2587 + @as(i64, 1);
    const v2589: i64 = v2588 + @as(i64, 1);
    const v2590: i64 = v2589 + @as(i64, 1);
    const v2591: i64 = v2590 + @as(i64, 1);
    const v2592: i64 = @as(i64, 0) + @as(i64, 1);
    const v2593: i64 = v2592 + @as(i64, 1);
    const v2594: i64 = v2593 + @as(i64, 1);
    const v2595: i64 = v2594 + @as(i64, 1);
    const v2596: i64 = v2595 + @as(i64, 1);
    const v2597: bool = v2591 == v2596;
    if (v2597) {
        v2598 = @as(i64, 0);
    } else {
        v2598 = @as(i64, 1);
    }
    const v2601: i64 = v2586 +% v2598;
    const v2604: i64 = v2582 +% v2601;
    const v2605: i64 = v2572 +% v2604;
    const v2606: i64 = v2540 +% v2605;
    const v2607: i64 = @as(i64, 0) + @as(i64, 1);
    const v2608: i64 = v2607 + @as(i64, 1);
    const v2609: i64 = v2608 + @as(i64, 1);
    const v2610: i64 = v2609 + @as(i64, 1);
    const v2611: i64 = @as(i64, 0) + @as(i64, 1);
    const v2612: i64 = v2611 + @as(i64, 1);
    const v2613: i64 = v2612 + @as(i64, 1);
    const v2614: i64 = v2613 + @as(i64, 1);
    const v2615: bool = v2610 == v2614;
    if (v2615) {
        v2616 = @as(i64, 0);
    } else {
        v2616 = @as(i64, 1);
    }
    const v2617: i64 = @as(i64, 0) + @as(i64, 1);
    const v2618: i64 = @as(i64, 0) + @as(i64, 1);
    const v2619: bool = v2617 == v2618;
    if (v2619) {
        v2620 = @as(i64, 0);
    } else {
        v2620 = @as(i64, 1);
    }
    const v2621: i64 = @as(i64, 0) + @as(i64, 1);
    const v2622: i64 = v2621 + @as(i64, 1);
    const v2623: i64 = v2622 + @as(i64, 1);
    const v2624: i64 = v2623 + @as(i64, 1);
    const v2625: i64 = v2624 + @as(i64, 1);
    const v2626: i64 = @as(i64, 0) + @as(i64, 1);
    const v2627: i64 = v2626 + @as(i64, 1);
    const v2628: i64 = v2627 + @as(i64, 1);
    const v2629: i64 = v2628 + @as(i64, 1);
    const v2630: i64 = v2629 + @as(i64, 1);
    const v2631: bool = v2625 == v2630;
    if (v2631) {
        v2632 = @as(i64, 0);
    } else {
        v2632 = @as(i64, 1);
    }
    const v2633: i64 = v2617 +% v2625;
    const v2634: i64 = v2618 +% v2630;
    const v2635: i64 = v2620 +% v2632;
    const v2636: i64 = v2610 +% v2633;
    const v2637: i64 = v2614 +% v2634;
    const v2638: i64 = v2616 +% v2635;
    const v2639: i64 = v2637 +% v2638;
    const v2640: i64 = v2636 +% v2639;
    const v2641: i64 = @as(i64, 3) +% v2640;
    const v2642: i64 = @as(i64, 0) + @as(i64, 1);
    const v2643: i64 = v2642 + @as(i64, 1);
    const v2644: i64 = v2643 + @as(i64, 1);
    const v2645: i64 = v2644 + @as(i64, 1);
    const v2646: i64 = @as(i64, 0) + @as(i64, 1);
    const v2647: i64 = v2646 + @as(i64, 1);
    const v2648: i64 = v2647 + @as(i64, 1);
    const v2649: i64 = v2648 + @as(i64, 1);
    const v2650: bool = v2645 == v2649;
    if (v2650) {
        v2651 = @as(i64, 0);
    } else {
        v2651 = @as(i64, 1);
    }
    const v2652: i64 = @as(i64, 0) + @as(i64, 1);
    const v2653: i64 = @as(i64, 0) + @as(i64, 1);
    const v2654: bool = v2652 == v2653;
    if (v2654) {
        v2655 = @as(i64, 0);
    } else {
        v2655 = @as(i64, 1);
    }
    const v2656: i64 = @as(i64, 0) + @as(i64, 1);
    const v2657: i64 = v2656 + @as(i64, 1);
    const v2658: i64 = v2657 + @as(i64, 1);
    const v2659: i64 = v2658 + @as(i64, 1);
    const v2660: i64 = v2659 + @as(i64, 1);
    const v2661: i64 = @as(i64, 0) + @as(i64, 1);
    const v2662: i64 = v2661 + @as(i64, 1);
    const v2663: i64 = v2662 + @as(i64, 1);
    const v2664: i64 = v2663 + @as(i64, 1);
    const v2665: i64 = v2664 + @as(i64, 1);
    const v2666: bool = v2660 == v2665;
    if (v2666) {
        v2667 = @as(i64, 0);
    } else {
        v2667 = @as(i64, 1);
    }
    const v2668: i64 = v2652 +% v2660;
    const v2669: i64 = v2653 +% v2665;
    const v2670: i64 = v2655 +% v2667;
    const v2671: i64 = v2645 +% v2668;
    const v2672: i64 = v2649 +% v2669;
    const v2673: i64 = v2651 +% v2670;
    const v2674: i64 = v2672 +% v2673;
    const v2675: i64 = v2671 +% v2674;
    const v2676: i64 = @as(i64, 3) +% v2675;
    const v2677: bool = v2641 == v2676;
    if (v2677) {
        v2678 = @as(i64, 0) + @as(i64, 1);
        v2679 = v2678 + @as(i64, 1);
        v2680 = v2679 + @as(i64, 1);
        v2681 = v2680 + @as(i64, 1);
        v2682 = @as(i64, 0) + @as(i64, 1);
        v2683 = v2682 + @as(i64, 1);
        v2684 = v2683 + @as(i64, 1);
        v2685 = v2684 + @as(i64, 1);
        v2686 = v2681 == v2685;
        if (v2686) {
            v2687 = @as(i64, 0);
        } else {
            v2687 = @as(i64, 1);
        }
        v2688 = @as(i64, 0) + @as(i64, 1);
        v2689 = @as(i64, 0) + @as(i64, 1);
        v2690 = v2688 == v2689;
        if (v2690) {
            v2691 = @as(i64, 0);
        } else {
            v2691 = @as(i64, 1);
        }
        v2692 = @as(i64, 0) + @as(i64, 1);
        v2693 = v2692 + @as(i64, 1);
        v2694 = v2693 + @as(i64, 1);
        v2695 = v2694 + @as(i64, 1);
        v2696 = v2695 + @as(i64, 1);
        v2697 = @as(i64, 0) + @as(i64, 1);
        v2698 = v2697 + @as(i64, 1);
        v2699 = v2698 + @as(i64, 1);
        v2700 = v2699 + @as(i64, 1);
        v2701 = v2700 + @as(i64, 1);
        v2702 = v2696 == v2701;
        if (v2702) {
            v2703 = @as(i64, 0);
        } else {
            v2703 = @as(i64, 1);
        }
        v2704 = v2688 +% v2696;
        v2705 = v2689 +% v2701;
        v2706 = v2691 +% v2703;
        v2707 = v2681 +% v2704;
        v2708 = v2685 +% v2705;
        v2709 = v2687 +% v2706;
        v2710 = "validated-restart-metrics-are-derived-only-after-the-current-frame-and-the-entire-tail-pass-checksum-validation";
        v2714 = US0_TypedFxHashedStatementChecksumValidationAccepted(@as(i64, 1), @as(i64, 3), v2707, v2708, v2709, v2710);
    } else {
        v2712 = "checksum-mismatch-blocks-the-frame-before-it-contributes-any-restart-metric";
        v2714 = US0_TypedFxHashedStatementChecksumValidationRejected(v2641, v2676, v2712);
    }
    switch (v2714.tag) {
        0 => {
            v2718 = v2714.c0_0;
            v2719 = v2714.c0_1;
            v2720 = v2714.c0_2;
            v2721 = v2714.c0_3;
            v2722 = v2714.c0_4;
            v2723 = v2714.c0_5;
            v2733 = @as(i64, 1);
            v2734 = @as(i64, 0);
            v2741 = v2722;
        },
        1 => {
            v2715 = v2714.c1_0;
            v2716 = v2714.c1_1;
            v2717 = v2714.c1_2;
            v2733 = @as(i64, 0);
            v2734 = @as(i64, 1);
            v2741 = @as(i64, 0);
        },
        else => unreachable,
    }
    const v2742: i64 = @as(i64, 0) + @as(i64, 1);
    const v2743: i64 = v2742 + @as(i64, 1);
    const v2744: i64 = v2743 + @as(i64, 1);
    const v2745: i64 = v2744 + @as(i64, 1);
    const v2746: i64 = @as(i64, 0) + @as(i64, 1);
    const v2747: i64 = v2746 + @as(i64, 1);
    const v2748: i64 = v2747 + @as(i64, 1);
    const v2749: i64 = v2748 + @as(i64, 1);
    const v2750: bool = v2745 == v2749;
    if (v2750) {
        v2751 = @as(i64, 0);
    } else {
        v2751 = @as(i64, 1);
    }
    const v2752: i64 = @as(i64, 0) + @as(i64, 1);
    const v2753: i64 = @as(i64, 0) + @as(i64, 1);
    const v2754: bool = v2752 == v2753;
    if (v2754) {
        v2755 = @as(i64, 0);
    } else {
        v2755 = @as(i64, 1);
    }
    const v2756: i64 = @as(i64, 0) + @as(i64, 1);
    const v2757: i64 = v2756 + @as(i64, 1);
    const v2758: i64 = v2757 + @as(i64, 1);
    const v2759: i64 = v2758 + @as(i64, 1);
    const v2760: i64 = v2759 + @as(i64, 1);
    const v2761: i64 = @as(i64, 0) + @as(i64, 1);
    const v2762: i64 = v2761 + @as(i64, 1);
    const v2763: i64 = v2762 + @as(i64, 1);
    const v2764: i64 = v2763 + @as(i64, 1);
    const v2765: i64 = v2764 + @as(i64, 1);
    const v2766: bool = v2760 == v2765;
    if (v2766) {
        v2767 = @as(i64, 0);
    } else {
        v2767 = @as(i64, 1);
    }
    const v2770: i64 = v2755 +% v2767;
    const v2773: i64 = v2751 +% v2770;
    const v2774: i64 = @as(i64, 0) + @as(i64, 1);
    const v2775: i64 = v2774 + @as(i64, 1);
    const v2776: i64 = v2775 + @as(i64, 1);
    const v2777: i64 = v2776 + @as(i64, 1);
    const v2778: i64 = @as(i64, 0) + @as(i64, 1);
    const v2779: i64 = v2778 + @as(i64, 1);
    const v2780: i64 = v2779 + @as(i64, 1);
    const v2781: i64 = v2780 + @as(i64, 1);
    const v2782: bool = v2777 == v2781;
    if (v2782) {
        v2783 = @as(i64, 0);
    } else {
        v2783 = @as(i64, 1);
    }
    const v2784: i64 = @as(i64, 0) + @as(i64, 1);
    const v2785: i64 = @as(i64, 0) + @as(i64, 1);
    const v2786: bool = v2784 == v2785;
    if (v2786) {
        v2787 = @as(i64, 0);
    } else {
        v2787 = @as(i64, 1);
    }
    const v2788: i64 = @as(i64, 0) + @as(i64, 1);
    const v2789: i64 = v2788 + @as(i64, 1);
    const v2790: i64 = v2789 + @as(i64, 1);
    const v2791: i64 = v2790 + @as(i64, 1);
    const v2792: i64 = v2791 + @as(i64, 1);
    const v2793: i64 = @as(i64, 0) + @as(i64, 1);
    const v2794: i64 = v2793 + @as(i64, 1);
    const v2795: i64 = v2794 + @as(i64, 1);
    const v2796: i64 = v2795 + @as(i64, 1);
    const v2797: i64 = v2796 + @as(i64, 1);
    const v2798: bool = v2792 == v2797;
    if (v2798) {
        v2799 = @as(i64, 0);
    } else {
        v2799 = @as(i64, 1);
    }
    const v2802: i64 = v2787 +% v2799;
    const v2805: i64 = v2783 +% v2802;
    const v2806: i64 = v2773 +% v2805;
    const v2807: i64 = v2741 +% v2734;
    const v2808: i64 = v2806 +% v2807;
    const v2809: i64 = v2606 +% v2808;
    const v2810: bool = v2733 == @as(i64, 1);
    const v2811: bool = v2809 == @as(i64, 0);
    const v2812: bool = (v2810 and v2811);
    if (v2812) {
    } else {
        if (spiral_true) spiralFail("typed-FX-statement-indexed-durable-commit-runtime-mismatch");
    }
    const v2813: i64 = @as(i64, 0) + @as(i64, 1);
    const v2814: i64 = v2813 + @as(i64, 1);
    const v2815: i64 = v2814 + @as(i64, 1);
    const v2816: i64 = v2815 + @as(i64, 1);
    const v2817: i64 = @as(i64, 0) + @as(i64, 1);
    const v2818: i64 = v2817 + @as(i64, 1);
    const v2819: i64 = v2818 + @as(i64, 1);
    const v2820: i64 = v2819 + @as(i64, 1);
    const v2821: bool = v2816 == v2820;
    if (v2821) {
        v2822 = @as(i64, 0);
    } else {
        v2822 = @as(i64, 1);
    }
    const v2823: i64 = @as(i64, 0) + @as(i64, 1);
    const v2824: i64 = @as(i64, 0) + @as(i64, 1);
    const v2825: bool = v2823 == v2824;
    if (v2825) {
        v2826 = @as(i64, 0);
    } else {
        v2826 = @as(i64, 1);
    }
    const v2827: i64 = @as(i64, 0) + @as(i64, 1);
    const v2828: i64 = v2827 + @as(i64, 1);
    const v2829: i64 = v2828 + @as(i64, 1);
    const v2830: i64 = v2829 + @as(i64, 1);
    const v2831: i64 = v2830 + @as(i64, 1);
    const v2832: i64 = @as(i64, 0) + @as(i64, 1);
    const v2833: i64 = v2832 + @as(i64, 1);
    const v2834: i64 = v2833 + @as(i64, 1);
    const v2835: i64 = v2834 + @as(i64, 1);
    const v2836: i64 = v2835 + @as(i64, 1);
    const v2837: bool = v2831 == v2836;
    if (v2837) {
        v2838 = @as(i64, 0);
    } else {
        v2838 = @as(i64, 1);
    }
    const v2839: i64 = v2823 +% v2831;
    const v2840: i64 = v2824 +% v2836;
    const v2841: i64 = v2826 +% v2838;
    const v2842: i64 = v2816 +% v2839;
    const v2843: i64 = v2820 +% v2840;
    const v2844: i64 = v2822 +% v2841;
    const v2845: i64 = @as(i64, 0) + @as(i64, 1);
    const v2846: i64 = v2845 + @as(i64, 1);
    const v2847: i64 = v2846 + @as(i64, 1);
    const v2848: i64 = v2847 + @as(i64, 1);
    const v2849: i64 = @as(i64, 0) + @as(i64, 1);
    const v2850: i64 = v2849 + @as(i64, 1);
    const v2851: i64 = v2850 + @as(i64, 1);
    const v2852: i64 = v2851 + @as(i64, 1);
    const v2853: bool = v2848 == v2852;
    if (v2853) {
        v2854 = @as(i64, 0);
    } else {
        v2854 = @as(i64, 1);
    }
    const v2855: i64 = @as(i64, 0) + @as(i64, 1);
    const v2856: i64 = @as(i64, 0) + @as(i64, 1);
    const v2857: bool = v2855 == v2856;
    if (v2857) {
        v2858 = @as(i64, 0);
    } else {
        v2858 = @as(i64, 1);
    }
    const v2859: i64 = @as(i64, 0) + @as(i64, 1);
    const v2860: i64 = v2859 + @as(i64, 1);
    const v2861: i64 = v2860 + @as(i64, 1);
    const v2862: i64 = v2861 + @as(i64, 1);
    const v2863: i64 = v2862 + @as(i64, 1);
    const v2864: i64 = @as(i64, 0) + @as(i64, 1);
    const v2865: i64 = v2864 + @as(i64, 1);
    const v2866: i64 = v2865 + @as(i64, 1);
    const v2867: i64 = v2866 + @as(i64, 1);
    const v2868: i64 = v2867 + @as(i64, 1);
    const v2869: bool = v2863 == v2868;
    if (v2869) {
        v2870 = @as(i64, 0);
    } else {
        v2870 = @as(i64, 1);
    }
    const v2871: i64 = v2855 +% v2863;
    const v2872: i64 = v2856 +% v2868;
    const v2873: i64 = v2858 +% v2870;
    const v2874: i64 = v2848 +% v2871;
    const v2875: i64 = v2852 +% v2872;
    const v2876: i64 = v2854 +% v2873;
    const v2877: i64 = @as(i64, 0) + @as(i64, 1);
    const v2878: i64 = v2877 + @as(i64, 1);
    const v2879: i64 = v2878 + @as(i64, 1);
    const v2880: i64 = v2879 + @as(i64, 1);
    const v2881: i64 = @as(i64, 0) + @as(i64, 1);
    const v2882: i64 = v2881 + @as(i64, 1);
    const v2883: i64 = v2882 + @as(i64, 1);
    const v2884: i64 = v2883 + @as(i64, 1);
    const v2885: bool = v2880 == v2884;
    if (v2885) {
        v2886 = @as(i64, 0);
    } else {
        v2886 = @as(i64, 1);
    }
    const v2887: i64 = @as(i64, 0) + @as(i64, 1);
    const v2888: i64 = @as(i64, 0) + @as(i64, 1);
    const v2889: bool = v2887 == v2888;
    if (v2889) {
        v2890 = @as(i64, 0);
    } else {
        v2890 = @as(i64, 1);
    }
    const v2891: i64 = @as(i64, 0) + @as(i64, 1);
    const v2892: i64 = v2891 + @as(i64, 1);
    const v2893: i64 = v2892 + @as(i64, 1);
    const v2894: i64 = v2893 + @as(i64, 1);
    const v2895: i64 = v2894 + @as(i64, 1);
    const v2896: i64 = @as(i64, 0) + @as(i64, 1);
    const v2897: i64 = v2896 + @as(i64, 1);
    const v2898: i64 = v2897 + @as(i64, 1);
    const v2899: i64 = v2898 + @as(i64, 1);
    const v2900: i64 = v2899 + @as(i64, 1);
    const v2901: bool = v2895 == v2900;
    if (v2901) {
        v2902 = @as(i64, 0);
    } else {
        v2902 = @as(i64, 1);
    }
    const v2903: i64 = v2887 +% v2895;
    const v2904: i64 = v2888 +% v2900;
    const v2905: i64 = v2890 +% v2902;
    const v2906: i64 = v2880 +% v2903;
    const v2907: i64 = v2884 +% v2904;
    const v2908: i64 = v2886 +% v2905;
    const v2909: i64 = @as(i64, 0) + @as(i64, 1);
    const v2910: i64 = v2909 + @as(i64, 1);
    const v2911: i64 = v2910 + @as(i64, 1);
    const v2912: i64 = v2911 + @as(i64, 1);
    const v2913: i64 = @as(i64, 0) + @as(i64, 1);
    const v2914: i64 = v2913 + @as(i64, 1);
    const v2915: i64 = v2914 + @as(i64, 1);
    const v2916: i64 = v2915 + @as(i64, 1);
    const v2917: bool = v2912 == v2916;
    if (v2917) {
        v2918 = @as(i64, 0);
    } else {
        v2918 = @as(i64, 1);
    }
    const v2919: i64 = @as(i64, 0) + @as(i64, 1);
    const v2920: i64 = @as(i64, 0) + @as(i64, 1);
    const v2921: bool = v2919 == v2920;
    if (v2921) {
        v2922 = @as(i64, 0);
    } else {
        v2922 = @as(i64, 1);
    }
    const v2923: i64 = @as(i64, 0) + @as(i64, 1);
    const v2924: i64 = v2923 + @as(i64, 1);
    const v2925: i64 = v2924 + @as(i64, 1);
    const v2926: i64 = v2925 + @as(i64, 1);
    const v2927: i64 = v2926 + @as(i64, 1);
    const v2928: i64 = @as(i64, 0) + @as(i64, 1);
    const v2929: i64 = v2928 + @as(i64, 1);
    const v2930: i64 = v2929 + @as(i64, 1);
    const v2931: i64 = v2930 + @as(i64, 1);
    const v2932: i64 = v2931 + @as(i64, 1);
    const v2933: bool = v2927 == v2932;
    if (v2933) {
        v2934 = @as(i64, 0);
    } else {
        v2934 = @as(i64, 1);
    }
    const v2935: i64 = v2919 +% v2927;
    const v2936: i64 = v2920 +% v2932;
    const v2937: i64 = v2922 +% v2934;
    const v2938: i64 = v2912 +% v2935;
    const v2939: i64 = v2916 +% v2936;
    const v2940: i64 = v2918 +% v2937;
    const v2941: i64 = v2906 +% v2938;
    const v2942: i64 = v2907 +% v2939;
    const v2943: i64 = v2908 +% v2940;
    const v2944: i64 = v2874 +% v2941;
    const v2945: i64 = v2875 +% v2942;
    const v2946: i64 = v2876 +% v2943;
    const v2947: i64 = v2842 +% v2944;
    const v2948: i64 = v2843 +% v2945;
    const v2949: i64 = v2844 +% v2946;
    const v2950: bool = v2947 == @as(i64, 40);
    const v2951: bool = v2948 == @as(i64, 40);
    const v2952: bool = v2949 == @as(i64, 0);
    const v2953: bool = (v2950 and v2951);
    const v2954: bool = (v2953 and v2952);
    if (v2954) {
    } else {
        if (spiral_true) spiralFail("typed-FX-hashed-statement-event-store-decision-runtime-mismatch");
    }
    const v2955: i64 = @as(i64, 0) + @as(i64, 1);
    const v2956: i64 = v2955 + @as(i64, 1);
    const v2957: i64 = v2956 + @as(i64, 1);
    const v2958: i64 = v2957 + @as(i64, 1);
    const v2959: i64 = @as(i64, 0) + @as(i64, 1);
    const v2960: i64 = v2959 + @as(i64, 1);
    const v2961: i64 = v2960 + @as(i64, 1);
    const v2962: i64 = v2961 + @as(i64, 1);
    const v2963: bool = v2958 == v2962;
    if (v2963) {
        v2964 = @as(i64, 0);
    } else {
        v2964 = @as(i64, 1);
    }
    const v2965: i64 = @as(i64, 0) + @as(i64, 1);
    const v2966: i64 = @as(i64, 0) + @as(i64, 1);
    const v2967: bool = v2965 == v2966;
    if (v2967) {
        v2968 = @as(i64, 0);
    } else {
        v2968 = @as(i64, 1);
    }
    const v2969: i64 = @as(i64, 0) + @as(i64, 1);
    const v2970: i64 = v2969 + @as(i64, 1);
    const v2971: i64 = v2970 + @as(i64, 1);
    const v2972: i64 = v2971 + @as(i64, 1);
    const v2973: i64 = v2972 + @as(i64, 1);
    const v2974: i64 = @as(i64, 0) + @as(i64, 1);
    const v2975: i64 = v2974 + @as(i64, 1);
    const v2976: i64 = v2975 + @as(i64, 1);
    const v2977: i64 = v2976 + @as(i64, 1);
    const v2978: i64 = v2977 + @as(i64, 1);
    const v2979: bool = v2973 == v2978;
    if (v2979) {
        v2980 = @as(i64, 0);
    } else {
        v2980 = @as(i64, 1);
    }
    const v2983: i64 = v2968 +% v2980;
    const v2986: i64 = v2964 +% v2983;
    const v2987: i64 = @as(i64, 0) + @as(i64, 1);
    const v2988: i64 = v2987 + @as(i64, 1);
    const v2989: i64 = v2988 + @as(i64, 1);
    const v2990: i64 = v2989 + @as(i64, 1);
    const v2991: i64 = @as(i64, 0) + @as(i64, 1);
    const v2992: i64 = v2991 + @as(i64, 1);
    const v2993: i64 = v2992 + @as(i64, 1);
    const v2994: i64 = v2993 + @as(i64, 1);
    const v2995: bool = v2990 == v2994;
    if (v2995) {
        v2996 = @as(i64, 0);
    } else {
        v2996 = @as(i64, 1);
    }
    const v2997: i64 = @as(i64, 0) + @as(i64, 1);
    const v2998: i64 = @as(i64, 0) + @as(i64, 1);
    const v2999: bool = v2997 == v2998;
    if (v2999) {
        v3000 = @as(i64, 0);
    } else {
        v3000 = @as(i64, 1);
    }
    const v3001: i64 = @as(i64, 0) + @as(i64, 1);
    const v3002: i64 = v3001 + @as(i64, 1);
    const v3003: i64 = v3002 + @as(i64, 1);
    const v3004: i64 = v3003 + @as(i64, 1);
    const v3005: i64 = v3004 + @as(i64, 1);
    const v3006: i64 = @as(i64, 0) + @as(i64, 1);
    const v3007: i64 = v3006 + @as(i64, 1);
    const v3008: i64 = v3007 + @as(i64, 1);
    const v3009: i64 = v3008 + @as(i64, 1);
    const v3010: i64 = v3009 + @as(i64, 1);
    const v3011: bool = v3005 == v3010;
    if (v3011) {
        v3012 = @as(i64, 0);
    } else {
        v3012 = @as(i64, 1);
    }
    const v3015: i64 = v3000 +% v3012;
    const v3018: i64 = v2996 +% v3015;
    const v3021: i64 = v3018 +% v2986;
    const v3022: i64 = @as(i64, 0) + @as(i64, 1);
    const v3023: i64 = v3022 + @as(i64, 1);
    const v3024: i64 = v3023 + @as(i64, 1);
    const v3025: i64 = v3024 + @as(i64, 1);
    const v3026: i64 = @as(i64, 0) + @as(i64, 1);
    const v3027: i64 = v3026 + @as(i64, 1);
    const v3028: i64 = v3027 + @as(i64, 1);
    const v3029: i64 = v3028 + @as(i64, 1);
    const v3030: bool = v3025 == v3029;
    if (v3030) {
        v3031 = @as(i64, 0);
    } else {
        v3031 = @as(i64, 1);
    }
    const v3032: i64 = @as(i64, 0) + @as(i64, 1);
    const v3033: i64 = @as(i64, 0) + @as(i64, 1);
    const v3034: bool = v3032 == v3033;
    if (v3034) {
        v3035 = @as(i64, 0);
    } else {
        v3035 = @as(i64, 1);
    }
    const v3036: i64 = @as(i64, 0) + @as(i64, 1);
    const v3037: i64 = v3036 + @as(i64, 1);
    const v3038: i64 = v3037 + @as(i64, 1);
    const v3039: i64 = v3038 + @as(i64, 1);
    const v3040: i64 = v3039 + @as(i64, 1);
    const v3041: i64 = @as(i64, 0) + @as(i64, 1);
    const v3042: i64 = v3041 + @as(i64, 1);
    const v3043: i64 = v3042 + @as(i64, 1);
    const v3044: i64 = v3043 + @as(i64, 1);
    const v3045: i64 = v3044 + @as(i64, 1);
    const v3046: bool = v3040 == v3045;
    if (v3046) {
        v3047 = @as(i64, 0);
    } else {
        v3047 = @as(i64, 1);
    }
    const v3050: i64 = v3035 +% v3047;
    const v3053: i64 = v3031 +% v3050;
    const v3054: i64 = @as(i64, 0) + @as(i64, 1);
    const v3055: i64 = v3054 + @as(i64, 1);
    const v3056: i64 = v3055 + @as(i64, 1);
    const v3057: i64 = v3056 + @as(i64, 1);
    const v3058: i64 = @as(i64, 0) + @as(i64, 1);
    const v3059: i64 = v3058 + @as(i64, 1);
    const v3060: i64 = v3059 + @as(i64, 1);
    const v3061: i64 = v3060 + @as(i64, 1);
    const v3062: bool = v3057 == v3061;
    if (v3062) {
        v3063 = @as(i64, 0);
    } else {
        v3063 = @as(i64, 1);
    }
    const v3064: i64 = @as(i64, 0) + @as(i64, 1);
    const v3065: i64 = @as(i64, 0) + @as(i64, 1);
    const v3066: bool = v3064 == v3065;
    if (v3066) {
        v3067 = @as(i64, 0);
    } else {
        v3067 = @as(i64, 1);
    }
    const v3068: i64 = @as(i64, 0) + @as(i64, 1);
    const v3069: i64 = v3068 + @as(i64, 1);
    const v3070: i64 = v3069 + @as(i64, 1);
    const v3071: i64 = v3070 + @as(i64, 1);
    const v3072: i64 = v3071 + @as(i64, 1);
    const v3073: i64 = @as(i64, 0) + @as(i64, 1);
    const v3074: i64 = v3073 + @as(i64, 1);
    const v3075: i64 = v3074 + @as(i64, 1);
    const v3076: i64 = v3075 + @as(i64, 1);
    const v3077: i64 = v3076 + @as(i64, 1);
    const v3078: bool = v3072 == v3077;
    if (v3078) {
        v3079 = @as(i64, 0);
    } else {
        v3079 = @as(i64, 1);
    }
    const v3082: i64 = v3067 +% v3079;
    const v3085: i64 = v3063 +% v3082;
    const v3088: i64 = v3085 +% v3053;
    const v3089: i64 = v3021 +% v3088;
    const v3090: bool = v3089 == @as(i64, 0);
    if (v3090) {
    } else {
        if (spiral_true) spiralFail("typed-FX-hashed-statement-proven-retry-runtime-mismatch");
    }
    const v3091: i64 = @as(i64, 0) + @as(i64, 1);
    const v3092: i64 = v3091 + @as(i64, 1);
    const v3093: i64 = v3092 + @as(i64, 1);
    const v3094: i64 = v3093 + @as(i64, 1);
    const v3095: i64 = @as(i64, 0) + @as(i64, 1);
    const v3096: i64 = v3095 + @as(i64, 1);
    const v3097: i64 = v3096 + @as(i64, 1);
    const v3098: i64 = v3097 + @as(i64, 1);
    const v3099: bool = v3094 == v3098;
    if (v3099) {
        v3100 = @as(i64, 0);
    } else {
        v3100 = @as(i64, 1);
    }
    const v3101: i64 = @as(i64, 0) + @as(i64, 1);
    const v3102: i64 = @as(i64, 0) + @as(i64, 1);
    const v3103: bool = v3101 == v3102;
    if (v3103) {
        v3104 = @as(i64, 0);
    } else {
        v3104 = @as(i64, 1);
    }
    const v3105: i64 = @as(i64, 0) + @as(i64, 1);
    const v3106: i64 = v3105 + @as(i64, 1);
    const v3107: i64 = v3106 + @as(i64, 1);
    const v3108: i64 = v3107 + @as(i64, 1);
    const v3109: i64 = v3108 + @as(i64, 1);
    const v3110: i64 = @as(i64, 0) + @as(i64, 1);
    const v3111: i64 = v3110 + @as(i64, 1);
    const v3112: i64 = v3111 + @as(i64, 1);
    const v3113: i64 = v3112 + @as(i64, 1);
    const v3114: i64 = v3113 + @as(i64, 1);
    const v3115: bool = v3109 == v3114;
    if (v3115) {
        v3116 = @as(i64, 0);
    } else {
        v3116 = @as(i64, 1);
    }
    const v3117: i64 = v3101 +% v3109;
    const v3118: i64 = v3102 +% v3114;
    const v3119: i64 = v3104 +% v3116;
    const v3120: i64 = v3094 +% v3117;
    const v3121: i64 = v3098 +% v3118;
    const v3122: i64 = v3100 +% v3119;
    const v3123: i64 = @as(i64, 0) + @as(i64, 1);
    const v3124: i64 = v3123 + @as(i64, 1);
    const v3125: i64 = v3124 + @as(i64, 1);
    const v3126: i64 = v3125 + @as(i64, 1);
    const v3127: i64 = @as(i64, 0) + @as(i64, 1);
    const v3128: i64 = v3127 + @as(i64, 1);
    const v3129: i64 = v3128 + @as(i64, 1);
    const v3130: i64 = v3129 + @as(i64, 1);
    const v3131: bool = v3126 == v3130;
    if (v3131) {
        v3132 = @as(i64, 0);
    } else {
        v3132 = @as(i64, 1);
    }
    const v3133: i64 = @as(i64, 0) + @as(i64, 1);
    const v3134: i64 = @as(i64, 0) + @as(i64, 1);
    const v3135: bool = v3133 == v3134;
    if (v3135) {
        v3136 = @as(i64, 0);
    } else {
        v3136 = @as(i64, 1);
    }
    const v3137: i64 = @as(i64, 0) + @as(i64, 1);
    const v3138: i64 = v3137 + @as(i64, 1);
    const v3139: i64 = v3138 + @as(i64, 1);
    const v3140: i64 = v3139 + @as(i64, 1);
    const v3141: i64 = v3140 + @as(i64, 1);
    const v3142: i64 = @as(i64, 0) + @as(i64, 1);
    const v3143: i64 = v3142 + @as(i64, 1);
    const v3144: i64 = v3143 + @as(i64, 1);
    const v3145: i64 = v3144 + @as(i64, 1);
    const v3146: i64 = v3145 + @as(i64, 1);
    const v3147: bool = v3141 == v3146;
    if (v3147) {
        v3148 = @as(i64, 0);
    } else {
        v3148 = @as(i64, 1);
    }
    const v3149: i64 = v3133 +% v3141;
    const v3150: i64 = v3134 +% v3146;
    const v3151: i64 = v3136 +% v3148;
    const v3152: i64 = v3126 +% v3149;
    const v3153: i64 = v3130 +% v3150;
    const v3154: i64 = v3132 +% v3151;
    const v3155: i64 = v3152 +% v3120;
    const v3156: i64 = v3153 +% v3121;
    const v3157: i64 = v3154 +% v3122;
    const v3158: bool = v3155 == @as(i64, 20);
    const v3159: bool = v3156 == @as(i64, 20);
    const v3160: bool = v3157 == @as(i64, 0);
    const v3161: bool = (v3158 and v3159);
    const v3162: bool = (v3161 and v3160);
    if (v3162) {
    } else {
        if (spiral_true) spiralFail("typed-FX-hashed-statement-history-enumeration-runtime-mismatch");
    }
    const v3163: i64 = @as(i64, 0) + @as(i64, 1);
    const v3164: i64 = v3163 + @as(i64, 1);
    const v3165: i64 = v3164 + @as(i64, 1);
    const v3166: i64 = v3165 + @as(i64, 1);
    const v3167: i64 = @as(i64, 0) + @as(i64, 1);
    const v3168: i64 = v3167 + @as(i64, 1);
    const v3169: i64 = v3168 + @as(i64, 1);
    const v3170: i64 = v3169 + @as(i64, 1);
    const v3171: bool = v3166 == v3170;
    if (v3171) {
        v3172 = @as(i64, 0);
    } else {
        v3172 = @as(i64, 1);
    }
    const v3173: i64 = @as(i64, 0) + @as(i64, 1);
    const v3174: i64 = @as(i64, 0) + @as(i64, 1);
    const v3175: bool = v3173 == v3174;
    if (v3175) {
        v3176 = @as(i64, 0);
    } else {
        v3176 = @as(i64, 1);
    }
    const v3177: i64 = @as(i64, 0) + @as(i64, 1);
    const v3178: i64 = v3177 + @as(i64, 1);
    const v3179: i64 = v3178 + @as(i64, 1);
    const v3180: i64 = v3179 + @as(i64, 1);
    const v3181: i64 = v3180 + @as(i64, 1);
    const v3182: i64 = @as(i64, 0) + @as(i64, 1);
    const v3183: i64 = v3182 + @as(i64, 1);
    const v3184: i64 = v3183 + @as(i64, 1);
    const v3185: i64 = v3184 + @as(i64, 1);
    const v3186: i64 = v3185 + @as(i64, 1);
    const v3187: bool = v3181 == v3186;
    if (v3187) {
        v3188 = @as(i64, 0);
    } else {
        v3188 = @as(i64, 1);
    }
    const v3189: i64 = v3173 +% v3181;
    const v3190: i64 = v3174 +% v3186;
    const v3191: i64 = v3176 +% v3188;
    const v3192: i64 = v3166 +% v3189;
    const v3193: i64 = v3170 +% v3190;
    const v3194: i64 = v3172 +% v3191;
    const v3195: bool = v3192 == @as(i64, 10);
    const v3196: bool = v3193 == @as(i64, 10);
    const v3197: bool = v3194 == @as(i64, 0);
    const v3198: bool = (v3195 and v3196);
    const v3199: bool = (v3198 and v3197);
    if (v3199) {
    } else {
        if (spiral_true) spiralFail("typed-FX-hashed-statement-history-index-lookup-runtime-mismatch");
    }
    const v3200: i64 = @as(i64, 0) + @as(i64, 1);
    const v3201: i64 = v3200 + @as(i64, 1);
    const v3202: i64 = v3201 + @as(i64, 1);
    const v3203: i64 = v3202 + @as(i64, 1);
    const v3204: i64 = @as(i64, 0) + @as(i64, 1);
    const v3205: i64 = v3204 + @as(i64, 1);
    const v3206: i64 = v3205 + @as(i64, 1);
    const v3207: i64 = v3206 + @as(i64, 1);
    const v3208: bool = v3203 == v3207;
    if (v3208) {
        v3209 = @as(i64, 0);
    } else {
        v3209 = @as(i64, 1);
    }
    const v3210: i64 = @as(i64, 0) + @as(i64, 1);
    const v3211: i64 = @as(i64, 0) + @as(i64, 1);
    const v3212: bool = v3210 == v3211;
    if (v3212) {
        v3213 = @as(i64, 0);
    } else {
        v3213 = @as(i64, 1);
    }
    const v3214: i64 = @as(i64, 0) + @as(i64, 1);
    const v3215: i64 = v3214 + @as(i64, 1);
    const v3216: i64 = v3215 + @as(i64, 1);
    const v3217: i64 = v3216 + @as(i64, 1);
    const v3218: i64 = v3217 + @as(i64, 1);
    const v3219: i64 = @as(i64, 0) + @as(i64, 1);
    const v3220: i64 = v3219 + @as(i64, 1);
    const v3221: i64 = v3220 + @as(i64, 1);
    const v3222: i64 = v3221 + @as(i64, 1);
    const v3223: i64 = v3222 + @as(i64, 1);
    const v3224: bool = v3218 == v3223;
    if (v3224) {
        v3225 = @as(i64, 0);
    } else {
        v3225 = @as(i64, 1);
    }
    const v3226: i64 = v3210 +% v3218;
    const v3227: i64 = v3211 +% v3223;
    const v3228: i64 = v3213 +% v3225;
    const v3229: i64 = v3203 +% v3226;
    const v3230: i64 = v3207 +% v3227;
    const v3231: i64 = v3209 +% v3228;
    const v3232: i64 = @as(i64, 0) + @as(i64, 1);
    const v3233: i64 = v3232 + @as(i64, 1);
    const v3234: i64 = v3233 + @as(i64, 1);
    const v3235: i64 = v3234 + @as(i64, 1);
    const v3236: i64 = @as(i64, 0) + @as(i64, 1);
    const v3237: i64 = v3236 + @as(i64, 1);
    const v3238: i64 = v3237 + @as(i64, 1);
    const v3239: i64 = v3238 + @as(i64, 1);
    const v3240: bool = v3235 == v3239;
    if (v3240) {
        v3241 = @as(i64, 0);
    } else {
        v3241 = @as(i64, 1);
    }
    const v3242: i64 = @as(i64, 0) + @as(i64, 1);
    const v3243: i64 = @as(i64, 0) + @as(i64, 1);
    const v3244: bool = v3242 == v3243;
    if (v3244) {
        v3245 = @as(i64, 0);
    } else {
        v3245 = @as(i64, 1);
    }
    const v3246: i64 = @as(i64, 0) + @as(i64, 1);
    const v3247: i64 = v3246 + @as(i64, 1);
    const v3248: i64 = v3247 + @as(i64, 1);
    const v3249: i64 = v3248 + @as(i64, 1);
    const v3250: i64 = v3249 + @as(i64, 1);
    const v3251: i64 = @as(i64, 0) + @as(i64, 1);
    const v3252: i64 = v3251 + @as(i64, 1);
    const v3253: i64 = v3252 + @as(i64, 1);
    const v3254: i64 = v3253 + @as(i64, 1);
    const v3255: i64 = v3254 + @as(i64, 1);
    const v3256: bool = v3250 == v3255;
    if (v3256) {
        v3257 = @as(i64, 0);
    } else {
        v3257 = @as(i64, 1);
    }
    const v3258: i64 = v3242 +% v3250;
    const v3259: i64 = v3243 +% v3255;
    const v3260: i64 = v3245 +% v3257;
    const v3261: i64 = v3235 +% v3258;
    const v3262: i64 = v3239 +% v3259;
    const v3263: i64 = v3241 +% v3260;
    const v3264: bool = v3229 == @as(i64, 10);
    const v3265: bool = v3230 == @as(i64, 10);
    const v3266: bool = v3231 == @as(i64, 0);
    const v3267: bool = v3261 == @as(i64, 10);
    const v3268: bool = v3262 == @as(i64, 10);
    const v3269: bool = v3263 == @as(i64, 0);
    const v3270: bool = (v3264 and v3265);
    const v3271: bool = (v3270 and v3266);
    const v3272: bool = (v3271 and v3267);
    const v3273: bool = (v3272 and v3268);
    const v3274: bool = (v3273 and v3269);
    if (v3274) {
    } else {
        if (spiral_true) spiralFail("typed-FX-hashed-statement-identity-lookup-runtime-mismatch");
    }
    const v3275: i64 = @as(i64, 0) + @as(i64, 1);
    const v3276: i64 = v3275 + @as(i64, 1);
    const v3277: i64 = v3276 + @as(i64, 1);
    const v3278: i64 = v3277 + @as(i64, 1);
    const v3279: i64 = @as(i64, 0) + @as(i64, 1);
    const v3280: i64 = v3279 + @as(i64, 1);
    const v3281: i64 = v3280 + @as(i64, 1);
    const v3282: i64 = v3281 + @as(i64, 1);
    const v3283: bool = v3278 == v3282;
    if (v3283) {
        v3284 = @as(i64, 0);
    } else {
        v3284 = @as(i64, 1);
    }
    const v3285: i64 = @as(i64, 0) + @as(i64, 1);
    const v3286: i64 = @as(i64, 0) + @as(i64, 1);
    const v3287: bool = v3285 == v3286;
    if (v3287) {
        v3288 = @as(i64, 0);
    } else {
        v3288 = @as(i64, 1);
    }
    const v3289: i64 = @as(i64, 0) + @as(i64, 1);
    const v3290: i64 = v3289 + @as(i64, 1);
    const v3291: i64 = v3290 + @as(i64, 1);
    const v3292: i64 = v3291 + @as(i64, 1);
    const v3293: i64 = v3292 + @as(i64, 1);
    const v3294: i64 = @as(i64, 0) + @as(i64, 1);
    const v3295: i64 = v3294 + @as(i64, 1);
    const v3296: i64 = v3295 + @as(i64, 1);
    const v3297: i64 = v3296 + @as(i64, 1);
    const v3298: i64 = v3297 + @as(i64, 1);
    const v3299: bool = v3293 == v3298;
    if (v3299) {
        v3300 = @as(i64, 0);
    } else {
        v3300 = @as(i64, 1);
    }
    const v3301: i64 = v3285 +% v3293;
    const v3302: i64 = v3286 +% v3298;
    const v3303: i64 = v3288 +% v3300;
    const v3304: i64 = v3278 +% v3301;
    const v3305: i64 = v3282 +% v3302;
    const v3306: i64 = v3284 +% v3303;
    const v3307: i64 = @as(i64, 0) + @as(i64, 1);
    const v3308: i64 = v3307 + @as(i64, 1);
    const v3309: i64 = v3308 + @as(i64, 1);
    const v3310: i64 = v3309 + @as(i64, 1);
    const v3311: i64 = @as(i64, 0) + @as(i64, 1);
    const v3312: i64 = v3311 + @as(i64, 1);
    const v3313: i64 = v3312 + @as(i64, 1);
    const v3314: i64 = v3313 + @as(i64, 1);
    const v3315: bool = v3310 == v3314;
    if (v3315) {
        v3316 = @as(i64, 0);
    } else {
        v3316 = @as(i64, 1);
    }
    const v3317: i64 = @as(i64, 0) + @as(i64, 1);
    const v3318: i64 = @as(i64, 0) + @as(i64, 1);
    const v3319: bool = v3317 == v3318;
    if (v3319) {
        v3320 = @as(i64, 0);
    } else {
        v3320 = @as(i64, 1);
    }
    const v3321: i64 = @as(i64, 0) + @as(i64, 1);
    const v3322: i64 = v3321 + @as(i64, 1);
    const v3323: i64 = v3322 + @as(i64, 1);
    const v3324: i64 = v3323 + @as(i64, 1);
    const v3325: i64 = v3324 + @as(i64, 1);
    const v3326: i64 = @as(i64, 0) + @as(i64, 1);
    const v3327: i64 = v3326 + @as(i64, 1);
    const v3328: i64 = v3327 + @as(i64, 1);
    const v3329: i64 = v3328 + @as(i64, 1);
    const v3330: i64 = v3329 + @as(i64, 1);
    const v3331: bool = v3325 == v3330;
    if (v3331) {
        v3332 = @as(i64, 0);
    } else {
        v3332 = @as(i64, 1);
    }
    const v3333: i64 = v3317 +% v3325;
    const v3334: i64 = v3318 +% v3330;
    const v3335: i64 = v3320 +% v3332;
    const v3336: i64 = v3310 +% v3333;
    const v3337: i64 = v3314 +% v3334;
    const v3338: i64 = v3316 +% v3335;
    const v3339: i64 = v3304 +% v3336;
    const v3340: i64 = v3305 +% v3337;
    const v3341: i64 = v3306 +% v3338;
    const v3342: bool = v3339 == @as(i64, 20);
    const v3343: bool = v3340 == @as(i64, 20);
    const v3344: bool = v3341 == @as(i64, 0);
    const v3345: bool = (v3342 and v3343);
    const v3346: bool = (v3345 and v3344);
    if (v3346) {
    } else {
        if (spiral_true) spiralFail("typed-FX-hashed-statement-membership-lookup-program-runtime-mismatch");
    }
    const v3347: i64 = @as(i64, 0) + @as(i64, 1);
    const v3348: i64 = v3347 + @as(i64, 1);
    const v3349: i64 = v3348 + @as(i64, 1);
    const v3350: i64 = v3349 + @as(i64, 1);
    const v3351: i64 = @as(i64, 0) + @as(i64, 1);
    const v3352: i64 = v3351 + @as(i64, 1);
    const v3353: i64 = v3352 + @as(i64, 1);
    const v3354: i64 = v3353 + @as(i64, 1);
    const v3355: bool = v3350 == v3354;
    if (v3355) {
        v3356 = @as(i64, 0);
    } else {
        v3356 = @as(i64, 1);
    }
    const v3357: i64 = @as(i64, 0) + @as(i64, 1);
    const v3358: i64 = @as(i64, 0) + @as(i64, 1);
    const v3359: bool = v3357 == v3358;
    if (v3359) {
        v3360 = @as(i64, 0);
    } else {
        v3360 = @as(i64, 1);
    }
    const v3361: i64 = @as(i64, 0) + @as(i64, 1);
    const v3362: i64 = v3361 + @as(i64, 1);
    const v3363: i64 = v3362 + @as(i64, 1);
    const v3364: i64 = v3363 + @as(i64, 1);
    const v3365: i64 = v3364 + @as(i64, 1);
    const v3366: i64 = @as(i64, 0) + @as(i64, 1);
    const v3367: i64 = v3366 + @as(i64, 1);
    const v3368: i64 = v3367 + @as(i64, 1);
    const v3369: i64 = v3368 + @as(i64, 1);
    const v3370: i64 = v3369 + @as(i64, 1);
    const v3371: bool = v3365 == v3370;
    if (v3371) {
        v3372 = @as(i64, 0);
    } else {
        v3372 = @as(i64, 1);
    }
    const v3373: i64 = v3357 +% v3365;
    const v3374: i64 = v3358 +% v3370;
    const v3375: i64 = v3360 +% v3372;
    const v3376: i64 = v3350 +% v3373;
    const v3377: i64 = v3354 +% v3374;
    const v3378: i64 = v3356 +% v3375;
    const v3379: i64 = @as(i64, 0) + @as(i64, 1);
    const v3380: i64 = v3379 + @as(i64, 1);
    const v3381: i64 = v3380 + @as(i64, 1);
    const v3382: i64 = v3381 + @as(i64, 1);
    const v3383: i64 = @as(i64, 0) + @as(i64, 1);
    const v3384: i64 = v3383 + @as(i64, 1);
    const v3385: i64 = v3384 + @as(i64, 1);
    const v3386: i64 = v3385 + @as(i64, 1);
    const v3387: bool = v3382 == v3386;
    if (v3387) {
        v3388 = @as(i64, 0);
    } else {
        v3388 = @as(i64, 1);
    }
    const v3389: i64 = @as(i64, 0) + @as(i64, 1);
    const v3390: i64 = @as(i64, 0) + @as(i64, 1);
    const v3391: bool = v3389 == v3390;
    if (v3391) {
        v3392 = @as(i64, 0);
    } else {
        v3392 = @as(i64, 1);
    }
    const v3393: i64 = @as(i64, 0) + @as(i64, 1);
    const v3394: i64 = v3393 + @as(i64, 1);
    const v3395: i64 = v3394 + @as(i64, 1);
    const v3396: i64 = v3395 + @as(i64, 1);
    const v3397: i64 = v3396 + @as(i64, 1);
    const v3398: i64 = @as(i64, 0) + @as(i64, 1);
    const v3399: i64 = v3398 + @as(i64, 1);
    const v3400: i64 = v3399 + @as(i64, 1);
    const v3401: i64 = v3400 + @as(i64, 1);
    const v3402: i64 = v3401 + @as(i64, 1);
    const v3403: bool = v3397 == v3402;
    if (v3403) {
        v3404 = @as(i64, 0);
    } else {
        v3404 = @as(i64, 1);
    }
    const v3405: i64 = v3389 +% v3397;
    const v3406: i64 = v3390 +% v3402;
    const v3407: i64 = v3392 +% v3404;
    const v3408: i64 = v3382 +% v3405;
    const v3409: i64 = v3386 +% v3406;
    const v3410: i64 = v3388 +% v3407;
    const v3411: i64 = v3376 +% v3408;
    const v3412: i64 = v3377 +% v3409;
    const v3413: i64 = v3378 +% v3410;
    const v3414: i64 = @as(i64, 0) + @as(i64, 1);
    const v3415: i64 = v3414 + @as(i64, 1);
    const v3416: i64 = v3415 + @as(i64, 1);
    const v3417: i64 = v3416 + @as(i64, 1);
    const v3418: i64 = @as(i64, 0) + @as(i64, 1);
    const v3419: i64 = v3418 + @as(i64, 1);
    const v3420: i64 = v3419 + @as(i64, 1);
    const v3421: i64 = v3420 + @as(i64, 1);
    const v3422: bool = v3417 == v3421;
    if (v3422) {
        v3423 = @as(i64, 0);
    } else {
        v3423 = @as(i64, 1);
    }
    const v3424: i64 = @as(i64, 0) + @as(i64, 1);
    const v3425: i64 = @as(i64, 0) + @as(i64, 1);
    const v3426: bool = v3424 == v3425;
    if (v3426) {
        v3427 = @as(i64, 0);
    } else {
        v3427 = @as(i64, 1);
    }
    const v3428: i64 = @as(i64, 0) + @as(i64, 1);
    const v3429: i64 = v3428 + @as(i64, 1);
    const v3430: i64 = v3429 + @as(i64, 1);
    const v3431: i64 = v3430 + @as(i64, 1);
    const v3432: i64 = v3431 + @as(i64, 1);
    const v3433: i64 = @as(i64, 0) + @as(i64, 1);
    const v3434: i64 = v3433 + @as(i64, 1);
    const v3435: i64 = v3434 + @as(i64, 1);
    const v3436: i64 = v3435 + @as(i64, 1);
    const v3437: i64 = v3436 + @as(i64, 1);
    const v3438: bool = v3432 == v3437;
    if (v3438) {
        v3439 = @as(i64, 0);
    } else {
        v3439 = @as(i64, 1);
    }
    const v3440: i64 = v3424 +% v3432;
    const v3441: i64 = v3425 +% v3437;
    const v3442: i64 = v3427 +% v3439;
    const v3443: i64 = v3417 +% v3440;
    const v3444: i64 = v3421 +% v3441;
    const v3445: i64 = v3423 +% v3442;
    const v3446: i64 = @as(i64, 0) + @as(i64, 1);
    const v3447: i64 = v3446 + @as(i64, 1);
    const v3448: i64 = v3447 + @as(i64, 1);
    const v3449: i64 = v3448 + @as(i64, 1);
    const v3450: i64 = @as(i64, 0) + @as(i64, 1);
    const v3451: i64 = v3450 + @as(i64, 1);
    const v3452: i64 = v3451 + @as(i64, 1);
    const v3453: i64 = v3452 + @as(i64, 1);
    const v3454: bool = v3449 == v3453;
    if (v3454) {
        v3455 = @as(i64, 0);
    } else {
        v3455 = @as(i64, 1);
    }
    const v3456: i64 = @as(i64, 0) + @as(i64, 1);
    const v3457: i64 = @as(i64, 0) + @as(i64, 1);
    const v3458: bool = v3456 == v3457;
    if (v3458) {
        v3459 = @as(i64, 0);
    } else {
        v3459 = @as(i64, 1);
    }
    const v3460: i64 = @as(i64, 0) + @as(i64, 1);
    const v3461: i64 = v3460 + @as(i64, 1);
    const v3462: i64 = v3461 + @as(i64, 1);
    const v3463: i64 = v3462 + @as(i64, 1);
    const v3464: i64 = v3463 + @as(i64, 1);
    const v3465: i64 = @as(i64, 0) + @as(i64, 1);
    const v3466: i64 = v3465 + @as(i64, 1);
    const v3467: i64 = v3466 + @as(i64, 1);
    const v3468: i64 = v3467 + @as(i64, 1);
    const v3469: i64 = v3468 + @as(i64, 1);
    const v3470: bool = v3464 == v3469;
    if (v3470) {
        v3471 = @as(i64, 0);
    } else {
        v3471 = @as(i64, 1);
    }
    const v3472: i64 = v3456 +% v3464;
    const v3473: i64 = v3457 +% v3469;
    const v3474: i64 = v3459 +% v3471;
    const v3475: i64 = v3449 +% v3472;
    const v3476: i64 = v3453 +% v3473;
    const v3477: i64 = v3455 +% v3474;
    const v3478: i64 = v3443 +% v3475;
    const v3479: bool = v3411 == v3478;
    const v3480: i64 = v3444 +% v3476;
    const v3481: bool = v3412 == v3480;
    const v3482: i64 = v3445 +% v3477;
    const v3483: bool = v3413 == v3482;
    const v3484: bool = (v3479 and v3481);
    const v3485: bool = (v3484 and v3483);
    if (v3485) {
    } else {
        if (spiral_true) spiralFail("typed-FX-hashed-statement-membership-lookup-program-append-runtime-mismatch");
    }
    const v3486: i64 = @as(i64, 0) + @as(i64, 1);
    const v3487: i64 = v3486 + @as(i64, 1);
    const v3488: i64 = v3487 + @as(i64, 1);
    const v3489: i64 = v3488 + @as(i64, 1);
    const v3490: i64 = @as(i64, 0) + @as(i64, 1);
    const v3491: i64 = v3490 + @as(i64, 1);
    const v3492: i64 = v3491 + @as(i64, 1);
    const v3493: i64 = v3492 + @as(i64, 1);
    const v3494: bool = v3489 == v3493;
    if (v3494) {
        v3495 = @as(i64, 0);
    } else {
        v3495 = @as(i64, 1);
    }
    const v3496: i64 = @as(i64, 0) + @as(i64, 1);
    const v3497: i64 = @as(i64, 0) + @as(i64, 1);
    const v3498: bool = v3496 == v3497;
    if (v3498) {
        v3499 = @as(i64, 0);
    } else {
        v3499 = @as(i64, 1);
    }
    const v3500: i64 = @as(i64, 0) + @as(i64, 1);
    const v3501: i64 = v3500 + @as(i64, 1);
    const v3502: i64 = v3501 + @as(i64, 1);
    const v3503: i64 = v3502 + @as(i64, 1);
    const v3504: i64 = v3503 + @as(i64, 1);
    const v3505: i64 = @as(i64, 0) + @as(i64, 1);
    const v3506: i64 = v3505 + @as(i64, 1);
    const v3507: i64 = v3506 + @as(i64, 1);
    const v3508: i64 = v3507 + @as(i64, 1);
    const v3509: i64 = v3508 + @as(i64, 1);
    const v3510: bool = v3504 == v3509;
    if (v3510) {
        v3511 = @as(i64, 0);
    } else {
        v3511 = @as(i64, 1);
    }
    const v3512: i64 = v3496 +% v3504;
    const v3513: i64 = v3497 +% v3509;
    const v3514: i64 = v3499 +% v3511;
    const v3515: i64 = v3489 +% v3512;
    const v3516: i64 = v3493 +% v3513;
    const v3517: i64 = v3495 +% v3514;
    const v3518: i64 = @as(i64, 0) + @as(i64, 1);
    const v3519: i64 = v3518 + @as(i64, 1);
    const v3520: i64 = v3519 + @as(i64, 1);
    const v3521: i64 = v3520 + @as(i64, 1);
    const v3522: i64 = @as(i64, 0) + @as(i64, 1);
    const v3523: i64 = v3522 + @as(i64, 1);
    const v3524: i64 = v3523 + @as(i64, 1);
    const v3525: i64 = v3524 + @as(i64, 1);
    const v3526: bool = v3521 == v3525;
    if (v3526) {
        v3527 = @as(i64, 0);
    } else {
        v3527 = @as(i64, 1);
    }
    const v3528: i64 = @as(i64, 0) + @as(i64, 1);
    const v3529: i64 = @as(i64, 0) + @as(i64, 1);
    const v3530: bool = v3528 == v3529;
    if (v3530) {
        v3531 = @as(i64, 0);
    } else {
        v3531 = @as(i64, 1);
    }
    const v3532: i64 = @as(i64, 0) + @as(i64, 1);
    const v3533: i64 = v3532 + @as(i64, 1);
    const v3534: i64 = v3533 + @as(i64, 1);
    const v3535: i64 = v3534 + @as(i64, 1);
    const v3536: i64 = v3535 + @as(i64, 1);
    const v3537: i64 = @as(i64, 0) + @as(i64, 1);
    const v3538: i64 = v3537 + @as(i64, 1);
    const v3539: i64 = v3538 + @as(i64, 1);
    const v3540: i64 = v3539 + @as(i64, 1);
    const v3541: i64 = v3540 + @as(i64, 1);
    const v3542: bool = v3536 == v3541;
    if (v3542) {
        v3543 = @as(i64, 0);
    } else {
        v3543 = @as(i64, 1);
    }
    const v3544: i64 = v3528 +% v3536;
    const v3545: i64 = v3529 +% v3541;
    const v3546: i64 = v3531 +% v3543;
    const v3547: i64 = v3521 +% v3544;
    const v3548: i64 = v3525 +% v3545;
    const v3549: i64 = v3527 +% v3546;
    const v3550: i64 = @as(i64, 0) + @as(i64, 1);
    const v3551: i64 = v3550 + @as(i64, 1);
    const v3552: i64 = v3551 + @as(i64, 1);
    const v3553: i64 = v3552 + @as(i64, 1);
    const v3554: i64 = @as(i64, 0) + @as(i64, 1);
    const v3555: i64 = v3554 + @as(i64, 1);
    const v3556: i64 = v3555 + @as(i64, 1);
    const v3557: i64 = v3556 + @as(i64, 1);
    const v3558: bool = v3553 == v3557;
    if (v3558) {
        v3559 = @as(i64, 0);
    } else {
        v3559 = @as(i64, 1);
    }
    const v3560: i64 = @as(i64, 0) + @as(i64, 1);
    const v3561: i64 = @as(i64, 0) + @as(i64, 1);
    const v3562: bool = v3560 == v3561;
    if (v3562) {
        v3563 = @as(i64, 0);
    } else {
        v3563 = @as(i64, 1);
    }
    const v3564: i64 = @as(i64, 0) + @as(i64, 1);
    const v3565: i64 = v3564 + @as(i64, 1);
    const v3566: i64 = v3565 + @as(i64, 1);
    const v3567: i64 = v3566 + @as(i64, 1);
    const v3568: i64 = v3567 + @as(i64, 1);
    const v3569: i64 = @as(i64, 0) + @as(i64, 1);
    const v3570: i64 = v3569 + @as(i64, 1);
    const v3571: i64 = v3570 + @as(i64, 1);
    const v3572: i64 = v3571 + @as(i64, 1);
    const v3573: i64 = v3572 + @as(i64, 1);
    const v3574: bool = v3568 == v3573;
    if (v3574) {
        v3575 = @as(i64, 0);
    } else {
        v3575 = @as(i64, 1);
    }
    const v3576: i64 = v3560 +% v3568;
    const v3577: i64 = v3561 +% v3573;
    const v3578: i64 = v3563 +% v3575;
    const v3579: i64 = v3553 +% v3576;
    const v3580: i64 = v3557 +% v3577;
    const v3581: i64 = v3559 +% v3578;
    const v3582: i64 = @as(i64, 0) + @as(i64, 1);
    const v3583: i64 = v3582 + @as(i64, 1);
    const v3584: i64 = v3583 + @as(i64, 1);
    const v3585: i64 = v3584 + @as(i64, 1);
    const v3586: i64 = @as(i64, 0) + @as(i64, 1);
    const v3587: i64 = v3586 + @as(i64, 1);
    const v3588: i64 = v3587 + @as(i64, 1);
    const v3589: i64 = v3588 + @as(i64, 1);
    const v3590: bool = v3585 == v3589;
    if (v3590) {
        v3591 = @as(i64, 0);
    } else {
        v3591 = @as(i64, 1);
    }
    const v3592: i64 = @as(i64, 0) + @as(i64, 1);
    const v3593: i64 = @as(i64, 0) + @as(i64, 1);
    const v3594: bool = v3592 == v3593;
    if (v3594) {
        v3595 = @as(i64, 0);
    } else {
        v3595 = @as(i64, 1);
    }
    const v3596: i64 = @as(i64, 0) + @as(i64, 1);
    const v3597: i64 = v3596 + @as(i64, 1);
    const v3598: i64 = v3597 + @as(i64, 1);
    const v3599: i64 = v3598 + @as(i64, 1);
    const v3600: i64 = v3599 + @as(i64, 1);
    const v3601: i64 = @as(i64, 0) + @as(i64, 1);
    const v3602: i64 = v3601 + @as(i64, 1);
    const v3603: i64 = v3602 + @as(i64, 1);
    const v3604: i64 = v3603 + @as(i64, 1);
    const v3605: i64 = v3604 + @as(i64, 1);
    const v3606: bool = v3600 == v3605;
    if (v3606) {
        v3607 = @as(i64, 0);
    } else {
        v3607 = @as(i64, 1);
    }
    const v3608: i64 = v3592 +% v3600;
    const v3609: i64 = v3593 +% v3605;
    const v3610: i64 = v3595 +% v3607;
    const v3611: i64 = v3585 +% v3608;
    const v3612: i64 = v3589 +% v3609;
    const v3613: i64 = v3591 +% v3610;
    const v3614: bool = v3515 == v3547;
    const v3615: bool = v3516 == v3548;
    const v3616: bool = v3517 == v3549;
    const v3617: bool = (v3614 and v3615);
    const v3618: bool = (v3617 and v3616);
    if (v3618) {
    } else {
        if (spiral_true) spiralFail("typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch");
    }
    const v3619: bool = v3579 == v3611;
    const v3620: bool = v3580 == v3612;
    const v3621: bool = v3581 == v3613;
    const v3622: bool = (v3619 and v3620);
    const v3623: bool = (v3622 and v3621);
    if (v3623) {
    } else {
        if (spiral_true) spiralFail("typed-FX-hashed-statement-identity-retry-stability-runtime-mismatch");
    }
    return @as(i32, 0);
}
var spiral_exit_code: i32 = 0;
fn spiralMainThread() void {
    spiral_exit_code = spiralMain();
}
extern "kernel32" fn CreateThread(attributes: ?*anyopaque, stack_size: usize, start: *const fn (?*anyopaque) callconv(.winapi) u32, parameter: ?*anyopaque, flags: u32, id: ?*u32) callconv(.winapi) ?std.os.windows.HANDLE;
extern "kernel32" fn WaitForSingleObject(handle: std.os.windows.HANDLE, milliseconds: u32) callconv(.winapi) u32;
extern "kernel32" fn ExitProcess(code: u32) callconv(.winapi) noreturn;
fn spiralMainThreadReserved(_: ?*anyopaque) callconv(.winapi) u32 {
    spiralMainThread();
    return 0;
}
pub fn main(init: std.process.Init.Minimal) void {
    spiral_gpa = spiral_arena.allocator();
    spiral_environ = init.environ;
    if (@import("builtin").os.tag == .windows) {
        const handle = CreateThread(null, 1 << 30, spiralMainThreadReserved, null, 0x00010000, null) orelse @panic("spiral: could not start the main thread");
        _ = WaitForSingleObject(handle, 0xFFFFFFFF);
    } else {
        const thread = std.Thread.spawn(.{ .stack_size = 1 << 30 }, spiralMainThread, .{}) catch @panic("spiral: could not start the main thread");
        thread.join();
    }
    spiralFlush();
    if (@import("builtin").os.tag == .windows) ExitProcess(@bitCast(spiral_exit_code)) else std.process.exit(@truncate(@as(u32, @bitCast(spiral_exit_code))));
}
