﻿using backend.Models;
using backend.Dto.Bid;
using Stripe;

namespace backend.Mappers
{
    public static class BidMappers
    {
        public static BidDto ToBidDto(this Bid bidModel) 
        {
            return new BidDto
            {
                Id = bidModel.Id,
                Amount = bidModel.Amount,
                UserId = bidModel.UserId,
                AuctionId = bidModel.AuctionId,
                PaymentIntentId = bidModel.PaymentIntentId,
                BidDate = bidModel.BidDate,
            };
        
        }

        public static Bid ToPlaceBidDto(this PlaceBidDto bidDto, string userId, string paymentIntentId) 
        {
            return new Bid
            {
                Amount = bidDto.Amount,
                UserId = userId,
                AuctionId = bidDto.AuctionId,
                PaymentIntentId =  paymentIntentId
    };
        }
    }
}
